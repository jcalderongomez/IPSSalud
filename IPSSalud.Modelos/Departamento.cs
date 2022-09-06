using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.Modelos
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string CodigoDaneDepartamento { get; set; }

        [Required]
        [MaxLength(80)]
        public string NombreDepartamento { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
