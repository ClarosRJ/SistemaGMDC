using Sis.Alcaldia.Server.Models;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Contratos
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Lista();
        Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
        Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null);

        Task<Usuario> TraerUser(string username, string correo);
    }
}
