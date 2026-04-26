using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColegioSanJose.Models
{
    public class Expediente
    {
        // Tabla Expediente
        public int ExpedienteId { get; set; }

        // Validaciones formulario de registro de expedientes

        [Required(ErrorMessage = "Seleccione el alumno")]
        [Display(Name = "Alumno")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "Seleccione la materia")]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "Ingrese la nota final")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        [Display(Name = "Nota Final")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal NotaFinal { get; set; }

        [StringLength(200)]
        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        // Relaciones
        public Alumno? Alumno { get; set; }
        public Materia? Materia { get; set; }
    }
}