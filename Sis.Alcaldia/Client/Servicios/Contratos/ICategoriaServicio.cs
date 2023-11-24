using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO entidad);
        Task<bool> Editar(CategoriaDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
