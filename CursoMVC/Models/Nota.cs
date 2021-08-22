using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Nota
    {
        [Key]
        public int NotaID { get; set; }
       public string calificacion { get; set; }

        public ICollection<Inscripcion> Inscripcion { get; set; }
    }
}
