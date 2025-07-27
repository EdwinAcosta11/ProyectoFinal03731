using Microsoft.AspNetCore.Mvc;
using ConsultorioDental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioDental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotivosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Motivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motivo>>> GetMotivos()
        {
            return await _context.Motivos.ToListAsync();
        }

        // GET: api/Motivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motivo>> GetMotivo(int id)
        {
            var motivo = await _context.Motivos.FindAsync(id);

            if (motivo == null)
            {
                return NotFound();
            }

            return motivo;
        }

        // POST: api/Motivos
        [HttpPost]
        public async Task<ActionResult<Motivo>> PostMotivo(Motivo motivo)
        {
            _context.Motivos.Add(motivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMotivo), new { id = motivo.MotivoId }, motivo);
        }

        // PUT: api/Motivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivo(int id, Motivo motivo)
        {
            if (id != motivo.MotivoId)
            {
                return BadRequest();
            }

            _context.Entry(motivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Motivos.Any(e => e.MotivoId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Motivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivo(int id)
        {
            var motivo = await _context.Motivos.FindAsync(id);
            if (motivo == null)
            {
                return NotFound();
            }

            _context.Motivos.Remove(motivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
