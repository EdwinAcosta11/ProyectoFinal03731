using ConsultorioDental.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Dentista
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DentistaId { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Especialidad { get; set; } = string.Empty;

    public List<Cita>? Citas { get; set; }
}

