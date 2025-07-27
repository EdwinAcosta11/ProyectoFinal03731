namespace ConsultorioDental.API.Models
{
    public class Dentista
    {
        public int DentistaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;

        // Lista de citas relacionadas
        public List<Cita>? Citas { get; set; }
    }
}
