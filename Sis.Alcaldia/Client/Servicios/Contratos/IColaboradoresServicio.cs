using Sis.Alcaldia.Shared.Models;
using Sis.Alcaldia.Shared.Models.Colaboradores;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IColaboradoresServicio
    {
        Task<ResponseDTO<List<ColaboradoresDTO>>> Lista();
        Task<ResponseDTO<ColaboradoresDTO>> Crear(ColaboradoresDTO entidad);
        Task<bool> Editar(ColaboradoresDTO entidad);
        Task<bool> Eliminar(int id);

        Task<ResponseDTO<ColaboradoresDTO>> Obtener(int IdColaborador);
        Task<ResponseDTO<List<ColaboradoresDTO>>> GetAllData();
        Task<ResponseDTO<List<ColaboradoresDTO>>> GetColFac(int IdColaborador);
        Task<ResponseDTO<List<ColaboradoresDTO>>> GetColFactPag(int IdColaborador,int IdFactura);

        //Facturas
        Task<ResponseDTO<ConfigContabilidadDTO>> ConfigConta();
        Task<ResponseDTO<FacturasDTO>> CrearFacturas(FacturasDTO entidad);
        Task<bool> EditarFacturas(FacturasDTO entidad);
        Task<bool> EliminarFacturas(int id);

        //Pagos
        Task<ResponseDTO<PagosDTO>> ListaPagos(int IdFact);
        Task<ResponseDTO<PagosDTO>> CrearPagos(PagosDTO entidad);
        Task<bool> EditarPagos(PagosDTO entidad);
        Task<bool> EliminarPagos(int id);
    }
}
