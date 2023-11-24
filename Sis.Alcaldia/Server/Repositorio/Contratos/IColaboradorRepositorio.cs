using Sis.Alcaldia.Client.Pages.Empleados;
using Sis.Alcaldia.Server.Models;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Contratos
{
    public interface IColaboradorRepositorio
    {
        Task<List<CliColaboradore>> Lista();
        Task<CliColaboradore> Obtener(Expression<Func<CliColaboradore, bool>> filtro = null);
        Task<CliColaboradore> Crear(CliColaboradore entidad);
        Task<bool> Editar(CliColaboradore entidad);
        Task<bool> Eliminar(CliColaboradore entidad);
        Task<IQueryable<CliColaboradore>> Consultar(Expression<Func<CliColaboradore, bool>> filtro = null);
        //aumentado
        Task<List<CliColaboradore>> GetColFac(int Id);
        Task<List<CliColaboradore>> GetAllData();
        Task<List<CliColaboradore>> GetColFactPag(int IdCol, int IdFac);

        //Facturas
        #region Facturas
        Task<ConfContabilidad> ConfigConta();
        Task<CliFactura> CrearFacturas(CliFactura entidad);
        Task<bool> EditarFacturas(CliFactura entidad);
        Task<bool> EliminarFacturas(CliFactura entidad);
        Task<CliFactura> ObtenerFacturas(Expression<Func<CliFactura, bool>> filtro = null);
        #endregion
        //Pagos
        #region Pagos
        Task<CliPago> CrearPagos(CliPago entidad);
        Task<bool> EditarPagos(CliPago entidad);
        Task<bool> EliminarPagos(CliPago entidad);
        Task<CliPago> ObtenerPagos(Expression<Func<CliPago, bool>> filtro = null);
        Task<CliPago> ListaPagos(int Id);
        #endregion

    }
}
