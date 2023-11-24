using Sis.Alcaldia.Server.Models;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Contratos
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categorium>> Lista();
        Task<Categorium> Obtener(Expression<Func<Categorium, bool>> filtro = null);
        Task<Categorium> Crear(Categorium entidad);
        Task<bool> Editar(Categorium entidad);
        Task<bool> Eliminar(Categorium entidad);
        Task<IQueryable<Categorium>> Consultar(Expression<Func<Categorium, bool>> filtro = null);
    }
}
