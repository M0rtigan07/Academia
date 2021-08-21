using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Curso
    {
        [Key]
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }
        public ICollection<Inscripcion> Inscripcion { get; set; }
        public ICollection<Docente> Docente { get; set; }

    }
}
