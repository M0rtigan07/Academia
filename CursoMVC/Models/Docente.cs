using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    
    public class Docente
    {
        [Key]
        public int DocenteID { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        [RegularExpression("^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$", ErrorMessage = "DNI incorrecto")]
        [Display(Name = "DNI")]
        public string DocenteDNI { get; set; }

        [Display(Name = "Curso")]
        public int CursoID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
       
        public Curso Curso { get; set; }
    }
}
