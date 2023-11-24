using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;

namespace Sis.Alcaldia.Server.Repositorio.Implementacion
{
    public class DashBoardRepositorio : IDashBoardRepositorio
    {
        private readonly DbblazorAlcaldiaContext _dbContext;

        public DashBoardRepositorio(DbblazorAlcaldiaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> HabitacionesDisponibles()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Where(h => h.IdEstadoHabitacion == 1).Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> HabitacionesLimpieza()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Where(h => h.IdEstadoHabitacion == 2).Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> HabitacionesOcupadas()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Where(h => h.IdEstadoHabitacion == 3).Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalHabitaciones()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }
    }
}
