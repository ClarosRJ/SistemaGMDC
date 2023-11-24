using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class RolUsuarioRepositorio : IRolUsuarioRepositorio
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public RolUsuarioRepositorio(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RolUsuario>> Lista()
        {
            try
            {
                return await _dbContext.RolUsuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
