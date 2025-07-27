using System.ComponentModel.DataAnnotations;

namespace ConsultorioDental.API.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Clave { get; set; }
    }
}
