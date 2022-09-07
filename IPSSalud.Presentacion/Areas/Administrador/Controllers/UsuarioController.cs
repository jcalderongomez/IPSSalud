using IPSSalud.AccesoDatos.Data;
using IPSSalud.Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;

namespace IPSSalud.Presentacion.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = DS.Role_Admin)]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsuarioController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodos() 
        {
            var usuarioLista = _db.UsuarioAplicacion.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var usuario in usuarioLista)
            {
                var roleID = userRole.FirstOrDefault(u => u.UserId == usuario.Id).RoleId;
                usuario.Role = roles.FirstOrDefault(u => u.Id == roleID).Name;
            }

            return Json(new { data = usuarioLista });

        }

        [HttpPost]
        public IActionResult BloquearDesbloquear([FromBody] string id)
        {
            var usuario = _db.UsuarioAplicacion.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return Json(new { success = false, message = "Error de Usuairo" });
            }

            if (usuario.LockoutEnd != null && usuario.LockoutEnd > DateTime.Now)
            {
                //Usuaio bloqueado
                usuario.LockoutEnd = DateTime.Now;
            }
            else
            {
                usuario.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Operación Exitosa" });
        }
        #endregion
    }
}
