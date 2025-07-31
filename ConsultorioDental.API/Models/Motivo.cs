using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioDental.API.Models
{
    public class Motivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MotivoId { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        public List<Cita>? Citas { get; set; }
    }
}

