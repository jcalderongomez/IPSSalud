using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos;
using IPSSalud.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPSSalud.Presentacion.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    //[Authorize(Roles = DS.Role_Admin)]
    public class EmpresaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmpresaController(IUnidadTrabajo unidadTrabao, IWebHostEnvironment hostEnvironment)
        {
            _unidadTrabajo = unidadTrabao;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            EmpresaVM empresaVM = new EmpresaVM()
            {
                Empresa = new Empresa(),
                DepartametoLista= _unidadTrabajo.Departamento.ObtenerTodos().Select(d => new SelectListItem
                {
                    Text = d.NombreDepartamento,
                    Value = d.Id.ToString()
                })

            };

            if (id == null)
            {
                //Esto es para crear nuevo registro
                return View(empresaVM);
            }
            //Esto espara actualizar
            empresaVM.Empresa = _unidadTrabajo.Empresa.Obtener(id.GetValueOrDefault());

            if (empresaVM.Empresa == null)
            {
                return NotFound();
            }
            return View(empresaVM);
        }


        #region
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmpresaVM empresaVM) 
        {
                if (ModelState.IsValid)
            {
                //Cargar Imagenes
                String webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"imagenes\empresas");
                    var extension = Path.GetExtension(files[0].FileName);
                    if (empresaVM.Empresa.LogoUrl != null)
                    {
                        //Esto es para editar, necesitamos borrar la imagen anterior
                        var imagenPath = Path.Combine(webRootPath, empresaVM.Empresa.LogoUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagenPath))
                        {
                            System.IO.File.Delete(imagenPath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    empresaVM.Empresa.LogoUrl = @"\imagenes\empresas\" + filename + extension;
                }
                else
                {
                    //si en el update el usuario no cambia la imagen
                    if (empresaVM.Empresa.Id != 0)
                    {
                        Empresa empresaDB = _unidadTrabajo.Empresa.Obtener(empresaVM.Empresa.Id);
                        empresaVM.Empresa.LogoUrl = empresaDB.LogoUrl;
                    }
                }

                if (empresaVM.Empresa.Id == 0)
                {
                    _unidadTrabajo.Empresa.Agregar(empresaVM.Empresa);
                }
                else
                {
                    _unidadTrabajo.Empresa.Actualizar(empresaVM.Empresa);
                }

                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                empresaVM.DepartametoLista= _unidadTrabajo.Departamento.ObtenerTodos().Select(m => new SelectListItem
                {
                    Text = m.NombreDepartamento,
                    Value = m.Id.ToString()
                });

                if (empresaVM.Empresa.Id != 0)
                {
                    empresaVM.Empresa = _unidadTrabajo.Empresa.Obtener(empresaVM.Empresa.Id);
                }
            }
            return View(empresaVM.Empresa);
        }


        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Empresa.ObtenerTodos(incluirPropiedades: "Municipio");
            return Json(new { data = todos });
        }
        #endregion
    }
}