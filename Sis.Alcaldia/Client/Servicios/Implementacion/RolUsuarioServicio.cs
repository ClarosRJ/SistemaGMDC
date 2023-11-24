using Sis.Alcaldia.Client.Servicios.Contratos;
using Sis.Alcaldia.Shared.Models;
using System.Net.Http.Json;

namespace Sis.Alcaldia.Client.Servicios.Implementacion
{
    public class RolUsuarioServicio : IRolUsuarioServicio
    {
        private readonly HttpClient _http;
        public RolUsuarioServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<RolUsuarioDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<RolUsuarioDTO>>>("api/rolusuario/Lista");
            return result!;
        }
    }
}
