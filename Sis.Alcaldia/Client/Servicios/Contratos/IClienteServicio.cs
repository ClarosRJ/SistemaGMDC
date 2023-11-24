using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IClienteServicio
    {
        Task<ResponseDTO<List<ClienteDTO>>> Lista();
        Task<ResponseDTO<ClienteDTO>> Crear(ClienteDTO entidad);
        Task<bool> Editar(ClienteDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
