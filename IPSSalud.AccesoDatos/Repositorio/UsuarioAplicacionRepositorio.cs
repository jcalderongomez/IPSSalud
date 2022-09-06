using IPSSalud.AccesoDatos.Data;
using IPSSalud.AccesoDatos.Repositorio.IRepositorio;
using IPSSalud.Modelos;

namespace IPSSalud.AccesoDatos.Repositorio
{
    public class UsuarioAplicacionRepositorio : Repositorio<UsuarioAplicacion>, IUsuarioAplicacionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioAplicacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}