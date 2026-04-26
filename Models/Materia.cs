using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models
{
    public class Materia
    {
        // Tabla Materia
        public int MateriaId { get; set; }

        // Validaciones formulario de registro de materias

        [Required(ErrorMessage = "Ingese el nombre de la materia")]
        [StringLength(100)]
        [Display(Name = "Materia")]
        public string? NombreMateria { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del docente")]
        [StringLength(100)]
        [Display(Name = "Docente")]
        public string? Docente { get; set; }

        // Relación: una materia puede estar en muchos expedientes
        public ICollection<Expediente>? Expedientes { get; set; }
    }
}