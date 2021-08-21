using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public enum Nota

    {

        A, B, C, D, F

    }
    public class Inscripcion
    {
        [Key]
        public int InscripcionID { get; set; }

        [Display(Name = "Curso")]
        public int CursoID { get; set; }
        [Display(Name = "DNI")]
        public string AlumnoDNI { get; set; }
        [Display(Name = "Apellidos del alumno")]
        public string AlumnoApellidos { get; set; }
        [Display(Name = "Nombre del alumno")]
        public string AlumnoNombre { get; set; }

        public Nota? Nota { get; set; }

        public Curso Curso { get; set; }

        public Alumno Alumno { get; set; }
    }
}
