using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Client.Pages.Empleados;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class ColaboradorRepositorio : IColaboradorRepositorio
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public ColaboradorRepositorio(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IQueryable<CliColaboradore>> Consultar(Expression<Func<CliColaboradore, bool>> filtro = null)
        {
            IQueryable<CliColaboradore> queryEntidad = filtro == null ? _dbContext.CliColaboradores : _dbContext.CliColaboradores.Where(filtro);
            return queryEntidad;
        }

        public async Task<CliColaboradore> Crear(CliColaboradore entidad)
        {
            try
            {
                _dbContext.Set<CliColaboradore>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CliColaboradore entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(CliColaboradore entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        //nuevos
        public async Task<List<CliColaboradore>> GetAllData()
        {
            var data = await _dbContext.CliColaboradores.ToListAsync();
            return data;
        }
        public async Task<List<CliColaboradore>> GetColFac(int Id)
        {
            var data = await _dbContext.CliColaboradores
                 .Where(r => r.Idcolaborador == Id)
                 .Include(f => f.CliFacturas)
                 .AsNoTracking()
                 .ToListAsync();

            return data;
        }
        public async Task<List<CliColaboradore>> GetColFactPag(int IdCol, int IdFac)
        {
            var data = await _dbContext.CliColaboradores
            .Where(c => c.Idcolaborador == IdCol)
            .Include(f => f.CliFacturas.Where(ff => ff.Idfactura == IdFac))
            .ThenInclude(p => p.CliPagos.Where(pp => pp.Idpago == IdFac))
            .AsNoTracking()
            .ToListAsync();

            return data;
        }
        //endnuevos
        public async Task<List<CliColaboradore>> Lista()
        {
            try
            {
                return await _dbContext.CliColaboradores.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<CliColaboradore> Obtener(Expression<Func<CliColaboradore, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.CliColaboradores.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        #region Facturas
        public async Task<ConfContabilidad> ConfigConta()
        {
            var gestion = DateTime.Now.Year.ToString();

            var data = await _dbContext.ConfContabilidads.Where(c => c.Gestion == gestion).FirstOrDefaultAsync();

            return data;
        }
        public async Task<CliFactura> CrearFacturas(CliFactura entidad)
        {
            try
            {
                _dbContext.Set<CliFactura>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> EditarFacturas(CliFactura entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }
        public async Task<bool> EliminarFacturas(CliFactura entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<CliFactura> ObtenerFacturas(Expression<Func<CliFactura, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.CliFacturas.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Pagos
        public async Task<CliPago> CrearPagos(CliPago entidad)
        {
            try
            {
               
                _dbContext.Set<CliPago>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> EditarPagos(CliPago entidad)
        {
            try
            {
              

                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> EliminarPagos(CliPago entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<CliPago> ObtenerPagos(Expression<Func<CliPago, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.CliPagos.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<CliPago> ListaPagos(int Id)
        {
            var data = await _dbContext.CliPagos
                 .Where(r => r.Idpago == Id)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            return data;
        }
        #endregion
    }
}