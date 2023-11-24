using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using System.Linq;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class PisoRepositorio : IPisoRepositorio
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public PisoRepositorio(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Piso>> Consultar(Expression<Func<Piso, bool>> filtro = null)
        {
            IQueryable<Piso> queryEntidad = filtro == null ? _dbContext.Pisos : _dbContext.Pisos.Where(filtro);
            return queryEntidad;
        }

        public async Task<Piso> Crear(Piso entidad)
        {
            try
            {
                _dbContext.Set<Piso>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Piso entidad)
        {
            try
            {
                _dbContext.Pisos.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Piso entidad)
        {
            try
            {
                _dbContext.Pisos.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Piso>> Lista()
        {
            try
            {
                return await _dbContext.Pisos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Piso> Obtener(Expression<Func<Piso, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Pisos.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
