using Sis.Alcaldia.Shared.Models.Colaboradores;
using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IConfigContabilidadServicio
    {
        Task<ResponseDTO<List<ConfigContabilidadDTO>>> GetAllData();
        Task<ResponseDTO<ConfigContabilidadDTO>> Crear(ConfigContabilidadDTO entidad);
        Task<bool> Editar(ConfigContabilidadDTO entidad);
        Task<bool> Eliminar(int id);
        Task<ResponseDTO<ConfigContabilidadDTO>> ItemId(int Id);

    }
}
