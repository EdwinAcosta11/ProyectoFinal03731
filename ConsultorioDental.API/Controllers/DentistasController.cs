using Microsoft.AspNetCore.Mvc;
using ConsultorioDental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioDental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentistasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DentistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dentistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dentista>>> GetDentistas()
        {
            return await _context.Dentistas.ToListAsync();
        }

        // GET: api/Dentistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dentista>> GetDentista(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);

            if (dentista == null)
            {
                return NotFound();
            }

            return dentista;
        }

        // POST: api/Dentistas
        [HttpPost]
        public async Task<ActionResult<Dentista>> PostDentista(Dentista dentista)
        {
            _context.Dentistas.Add(dentista);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDentista), new { id = dentista.DentistaId }, dentista);
        }

        // PUT: api/Dentistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDentista(int id, Dentista dentista)
        {
            if (id != dentista.DentistaId)
            {
                return BadRequest();
            }

            _context.Entry(dentista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Dentistas.Any(e => e.DentistaId == id))
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

        // DELETE: api/Dentistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista == null)
            {
                return NotFound();
            }

            _context.Dentistas.Remove(dentista);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}