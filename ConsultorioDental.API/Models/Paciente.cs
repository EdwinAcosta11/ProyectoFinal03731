namespace ConsultorioDental.API.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Lista de citas relacionadas
        public List<Cita>? Citas { get; set; }
    }
}
