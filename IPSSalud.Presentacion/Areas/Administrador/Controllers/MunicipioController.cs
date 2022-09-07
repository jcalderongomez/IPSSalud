using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var todos = _unidadTrabajo.Municipio.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}