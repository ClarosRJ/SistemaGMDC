using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IRolUsuarioServicio
    {
        Task<ResponseDTO<List<RolUsuarioDTO>>> Lista();
    }
}
