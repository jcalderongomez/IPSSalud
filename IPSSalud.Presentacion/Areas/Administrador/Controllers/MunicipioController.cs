using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IPSSalud.Presentacion.Areas.Administrador.Controllers
{
    [Area("Administrador")]
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
            var todos = _unidadTrabajo.Municipio.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}