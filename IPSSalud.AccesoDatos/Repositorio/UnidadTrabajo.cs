using IPSSalud.AccesoDatos.Data;
using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;

        public IEmpresaRepositorio Empresa { get; private set; }
        public IDepartamentoRepositorio Departamento { get; private set; }
        public IMunicipioRepositorio Municipio { get; private set; }
        public IUsuarioAplicacionRepositorio UsuarioAplicacion { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Empresa = new EmpresaRepositorio(_db);              //Inicializamos
            Departamento = new DepartamentoRepositorio(_db);    //Inicializamos
            Municipio = new MunicipioRepositorio(_db);          //Inicializamos
            UsuarioAplicacion = new UsuarioAplicacionRepositorio(_db); //Inicializamos
        }

        public void Guardar()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
