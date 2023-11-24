using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IRecepcionServicio
    {
        Task<ResponseDTO<RecepcionDTO>> Obtener(int idHabitacion);
        Task<ResponseDTO<RecepcionDTO>> Crear(RecepcionDTO entidad);
        Task<bool> Editar(RecepcionDTO entidad);
        Task<ResponseDTO<List<ReporteDTO>>> Reporte(string fechaInicio, string fechaFin);
    }
}
