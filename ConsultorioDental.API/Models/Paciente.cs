using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioDental.API.Models
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression(@"^\d{3}\d{7}\d{1}$", ErrorMessage = "La cédula debe tener 11 dígitos.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El teléfono no es válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede tener más de 15 caracteres.")]
        public string Telefono { get; set; } = string.Empty;

        public List<Cita>? Citas { get; set; }
    }
}


