using Sis.Alcaldia.Client.Pages.Empleados;
using Sis.Alcaldia.Server.Models;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Contratos
{
    public interface IConfigContabilidad
    {
        Task<List<ConfContabilidad>> GetAllData();
        Task<ConfContabilidad> ItemId(int Id);
        Task<ConfContabilidad> Crear(ConfContabilidad entidad);
        Task<bool> Editar(ConfContabilidad entidad);
        Task<bool> Eliminar(ConfContabilidad entidad);
        Task<ConfContabilidad> Filtrar(Expression<Func<ConfContabilidad, bool>> filtro = null);
    }
}
