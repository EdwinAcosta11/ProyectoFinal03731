using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioDental.API.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CitaId { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "El dentista es obligatorio.")]
        public int DentistaId { get; set; }

        [Required(ErrorMessage = "El motivo es obligatorio.")]
        public int MotivoId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria.")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(1, 240, ErrorMessage = "La duración debe estar entre 1 y 240 minutos.")]
        public int Duracion { get; set; } // minutos

        public string Estado { get; set; } = "Vigente"; // Estado por defecto

        // Relaciones (navigation properties)
        public Paciente? Paciente { get; set; }
        public Dentista? Dentista { get; set; }
        public Motivo? Motivo { get; set; }
    }
}
