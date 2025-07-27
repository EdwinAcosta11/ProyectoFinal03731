namespace ConsultorioDental.API.Models
{
    public class Motivo
    {
        public int MotivoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        // Lista de citas relacionadas
        public List<Cita>? Citas { get; set; }
    }
}
