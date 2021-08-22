using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
   /* public enum Nota

    {

        A, B, C, D, F

    }*/
    public class Inscripcion
    {
        [Key]
        public int InscripcionID { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [Display(Name = "Fecha de inscripción")]
        public DateTime FechaDeInscripcion { get; set; }

        [Display(Name = "Curso")]
        public int CursoID { get; set; }
        [Display(Name = "DNI")]
        public int AlumnoID { get; set; }
        [Display(Name = "Nota")]
        public int NotaID { get; set; }
        [Display(Name = "Apellidos")]
        public int AlumnoApellidos { get; set; }
        [Display(Name = "Nombre")]
        public string AlumnoNombre { get; set; }
       public string calificacion { get; set; }
        public Nota Nota { get; set; }

        public Curso Curso { get; set; }

        public Alumno Alumno { get; set; }
    }
}
