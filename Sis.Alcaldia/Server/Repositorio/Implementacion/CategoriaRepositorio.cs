using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using System.Linq;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public CategoriaRepositorio(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Categorium>> Consultar(Expression<Func<Categorium, bool>> filtro = null)
        {
            IQueryable<Categorium> queryEntidad = filtro == null ? _dbContext.Categoria : _dbContext.Categoria.Where(filtro);
            return queryEntidad;
        }

        public async Task<Categorium> Crear(Categorium entidad)
        {
            try
            {
                _dbContext.Set<Categorium>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Categorium entidad)
        {
            try
            {
                _dbContext.Categoria.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Categorium entidad)
        {
            try
            {
                _dbContext.Categoria.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Categorium>> Lista()
        {
            try
            {
                return await _dbContext.Categoria.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categorium> Obtener(Expression<Func<Categorium, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Categoria.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
