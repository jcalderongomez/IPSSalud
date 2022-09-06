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
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public DepartamentoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Departamento empresa)
        {
            var empresaDb = _db.Departamento.FirstOrDefault(d => d.Id == empresa.Id);
            if (empresaDb != null)
            {
                empresaDb.NombreDepartamento = empresa.NombreDepartamento;
                empresaDb.Estado = empresa.Estado;
            }
        }

    }
}
