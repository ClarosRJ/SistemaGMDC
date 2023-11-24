using Sis.Alcaldia.Server.Models;

namespace Sis.Alcaldia.Server.Repositorio.Contratos
{
    public interface IRolUsuarioRepositorio
    {
        Task<List<RolUsuario>> Lista();
    }
}
