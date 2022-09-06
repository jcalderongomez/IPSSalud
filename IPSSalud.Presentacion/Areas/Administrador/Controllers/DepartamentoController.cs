using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IPSSalud.Presentacion.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class DepartamentoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public DepartamentoController(IUnidadTrabajo unidadTrabao)
        {
            _unidadTrabajo = unidadTrabao;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Departamento.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}