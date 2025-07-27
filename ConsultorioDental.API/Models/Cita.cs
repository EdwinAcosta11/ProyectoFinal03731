namespace ConsultorioDental.API.Models
{
    public class Cita
    {
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public int DentistaId { get; set; }
        public int MotivoId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Duracion { get; set; } // minutos
        public string Estado { get; set; } // Calculado: Vigente, En proceso, Finalizado

        // Relaciones
        public Paciente? Paciente { get; set; }
        public Dentista? Dentista { get; set; }
        public Motivo? Motivo { get; set; }
    }
}
