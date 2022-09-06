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
    public class MunicipioRepositorio : Repositorio<Municipio>, IMunicipioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public MunicipioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Municipio municipio)
        {
            var municipioDb = _db.Municipio.FirstOrDefault(d => d.Id == municipio.Id);
            if (municipioDb != null)
            {
                municipioDb.NombreMunicipio = municipio.NombreMunicipio;
                municipioDb.Estado = municipio.Estado;
            }
        }

    }
}
