using Microsoft.AspNetCore.Mvc;
using ConsultorioDental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioDental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Dentista)
                .Include(c => c.Motivo)
                .ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Dentista)
                .Include(c => c.Motivo)
                .FirstOrDefaultAsync(c => c.CitaId == id);

            if (cita == null)
            {
                return NotFound();
            }

            return cita;
        }

        // POST: api/Citas
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            // Calcular estado en base a fecha y hora actual
            cita.Estado = CalcularEstado(cita.Fecha, cita.Hora, cita.Duracion);

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCita), new { id = cita.CitaId }, cita);
        }

        // PUT: api/Citas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.CitaId)
            {
                return BadRequest();
            }

            cita.Estado = CalcularEstado(cita.Fecha, cita.Hora, cita.Duracion);
            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Citas.Any(e => e.CitaId == id))
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

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método privado para calcular estado
        private string CalcularEstado(DateTime fecha, TimeSpan hora, int duracion)
        {
            var fechaHoraInicio = fecha.Date + hora;
            var fechaHoraFin = fechaHoraInicio.AddMinutes(duracion);
            var ahora = DateTime.Now;

            if (ahora < fechaHoraInicio)
                return "Vigente";
            else if (ahora >= fechaHoraInicio && ahora <= fechaHoraFin)
                return "En proceso";
            else
                return "Finalizado";
        }
    }
}
