using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSSalud.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IEmpresaRepositorio Empresa { get; }
        IDepartamentoRepositorio Departamento { get; }
        IMunicipioRepositorio Municipio { get; }
        //IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }

        void Guardar();
    }
}
