using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models
{
    public class Alumno
    {
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "Ingrese los nombres del alumno")]
        [StringLength(50)]
        [Display (Name = "Nombres")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Ingrese los apellidos del alumno")]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de nacimiento del alumno")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Ingrese el grado del alumno")]
        [StringLength(20)]
        [Display(Name = "Grado")]
        public string? Grado { get; set; }

        public ICollection<Expediente>? Expedientes { get; set; }
    }
}