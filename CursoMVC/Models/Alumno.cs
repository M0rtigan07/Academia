using Microsoft.EntityFrameworkCore;
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
        public string AlumnoDNI { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        [Display(Name = "Apellidos")]
        public string AlumnoApellidos { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        [Display(Name = "Nombre")]
        public string AlumnoNombre { get; set; }
                      
        public ICollection<Inscripcion> Inscripcion { get; set; }


    }
}
