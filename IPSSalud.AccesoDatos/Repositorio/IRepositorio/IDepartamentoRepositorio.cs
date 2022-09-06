using IPSSalud.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.AccesoDatos.Repositorio.IRepositorio
{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        void Actualizar(Departamento departamento);
    }
}
