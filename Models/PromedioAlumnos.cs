namespace ColegioSanJose.Models
{
    public class PromedioAlumnos
    {
        public int AlumnoId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Grado { get; set; }
        public decimal Promedio { get; set; }
        public int TotalMaterias { get; set; }
        public List<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}