using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IHabitacionServicio
    {
        Task<ResponseDTO<HabitacionDTO>> Obtener(int idHabitacion);
        Task<ResponseDTO<List<HabitacionDTO>>> Lista();
        Task<ResponseDTO<HabitacionDTO>> Crear(HabitacionDTO entidad);
        Task<bool> Editar(HabitacionDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
