using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IPisoServicio
    {
        Task<ResponseDTO<List<PisoDTO>>> Lista();
        Task<ResponseDTO<PisoDTO>> Crear(PisoDTO entidad);
        Task<bool> Editar(PisoDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
