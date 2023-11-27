using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using System.Linq.Expressions;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public UsuarioRepositorio(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            IQueryable<Usuario> queryEntidad = filtro == null ? _dbContext.Usuarios : _dbContext.Usuarios.Where(filtro);
            return queryEntidad;
        }

        public async Task<Usuario> Crear(Usuario entidad)
        {
            try
            {
                entidad.UrlImg = "https://localhost:7127/images/271120231718_default.png";
                _dbContext.Set<Usuario>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario entidad)
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

        public async Task<bool> Eliminar(Usuario entidad)
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

        public async Task<List<Usuario>> Lista()
        {
            try
            {
                return await _dbContext.Usuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Usuarios.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> TraerUser(string username, string correo)
        {
            var data = await _dbContext.Usuarios.Where(c => c.NombreCompleto == username && c.Correo == correo)
                            .FirstOrDefaultAsync();
            return data;
        }
    }
}
