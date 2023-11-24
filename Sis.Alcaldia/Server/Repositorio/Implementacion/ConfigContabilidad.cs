using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Client.Pages.Empleados;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class ConfigContabilidad : IConfigContabilidad
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public ConfigContabilidad(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConfContabilidad>> GetAllData()
        {
            var data = await _dbContext.ConfContabilidads.ToListAsync();
            return data;
        }
        public async Task<ConfContabilidad> Crear(ConfContabilidad entidad)
        {
            try
            {
                entidad.Afp = entidad.Afp / 100;
                entidad.Rciva = entidad.Rciva / 100;
                entidad.Caja = entidad.Caja / 100;

                _dbContext.Set<ConfContabilidad>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }
        public async Task<ConfContabilidad> ItemId(int Id)
        {
            try
            {
                var data = await _dbContext.ConfContabilidads.Where(c=>c.IdConfig == Id).FirstOrDefaultAsync();
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ConfContabilidad entidad)
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

        public async Task<bool> Eliminar(ConfContabilidad entidad)
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

        public async Task<ConfContabilidad> Filtrar(Expression<Func<ConfContabilidad, bool>> filtro)
        {
            try
            {
                return await _dbContext.ConfContabilidads.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}