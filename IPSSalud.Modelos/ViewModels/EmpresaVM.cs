using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.Modelos.ViewModels
{
    public  class EmpresaVM
    {
        public Empresa Empresa { get; set; }
        public IEnumerable<SelectListItem> MunicipiosLista { get; set; }
        public IEnumerable<SelectListItem> DepartametoLista { get; set; }
    }
}