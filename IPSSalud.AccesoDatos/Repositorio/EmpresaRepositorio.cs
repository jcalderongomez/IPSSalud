using IPSSalud.AccesoDatos.Data;
using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.AccesoDatos.Repositorio
{
    public class EmpresaRepositorio : Repositorio<Empresa>, IEmpresaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EmpresaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Empresa empresa)
        {
            var empresaDb = _db.Empresa.FirstOrDefault(d => d.Id == empresa.Id);
            if (empresaDb != null)
            {
                empresaDb.NombreEmpresa = empresa.NombreEmpresa;
                empresaDb.Estado = empresa.Estado;
            }
        }

    }
}
