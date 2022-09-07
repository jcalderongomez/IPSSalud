using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos;
using IPSSalud.Modelos.ViewModels;
using IPSSalud.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace IPSSalud.Presentacion.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = DS.Role_Admin)]
    public class MunicipioController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public MunicipioController(IUnidadTrabajo unidadTrabao)
        {
            _unidadTrabajo = unidadTrabao;
        }

        public IActionResult Index() {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodos() 
        {
            var todos = _unidadTrabajo.Municipio.ObtenerTodos(incluirPropiedades: "Departamento");
            return Json(new { data = todos });
        }

        [HttpGet]
        public IActionResult MunicipioDepartamento(int Id)
        {
            var todos = _unidadTrabajo.Municipio.Obtener(Id);
            EmpresaVM empresaVM = new EmpresaVM()
            {
                Empresa = new Empresa(),
                MunicipiosLista = _unidadTrabajo.Municipio.ObtenerTodos(x => x.DepartamentoId == Id).Select(c => new SelectListItem
                {
                    Text = c.NombreMunicipio,
                    Value = c.Id.ToString()
                })
            };

            return Ok(empresaVM.MunicipiosLista);
        }



        #endregion
    }
}