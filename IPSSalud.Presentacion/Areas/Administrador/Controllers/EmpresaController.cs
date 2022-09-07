using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos;
using IPSSalud.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPSSalud.Presentacion.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = DS.Role_Admin)]
    public class EmpresaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public EmpresaController(IUnidadTrabajo unidadTrabao)
        {
            _unidadTrabajo = unidadTrabao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Empresa empresa = new Empresa();
            if (empresa == null)
            {
                //Esto es para crear nuevo registro
                return View(empresa);
            }
            //Esto espara actualizar
            empresa = _unidadTrabajo.Empresa.Obtener(id.GetValueOrDefault());
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }


        #region
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Empresa.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}