using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Alumno
    {
        [Key]
        public int AlumnoID { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        [RegularExpression("^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$", ErrorMessage = "DNI incorrecto")]
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [Display(Name = "Fecha de inscripción")]
        public DateTime FechaDeInscripcion { get; set; }
       
        [Display(Name = "Inscripción")]
        public ICollection<Inscripcion> Inscripcion { get; set; }


    }
}
