using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.Modelos
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string CodigoDaneMunicipio { get; set; }

        [Required]
        [MaxLength(80)]
        public string NombreMunicipio { get; set; }

        [Required]
        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
