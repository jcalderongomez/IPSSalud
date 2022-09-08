using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.Modelos
{
    public  class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NitEmpresa { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreEmpresa { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefono { get; set; }

        [Required]
        public int MunicipioId { get; set; }

        [ForeignKey("MunicipioId")]
        public Municipio Municipio { get; set; }
        public string LogoUrl { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
