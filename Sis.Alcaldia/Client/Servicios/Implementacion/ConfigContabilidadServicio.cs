using Sis.Alcaldia.Client.Servicios.Contratos;
using Sis.Alcaldia.Shared.Models;
using Sis.Alcaldia.Shared.Models.Colaboradores;
using System.Net.Http.Json;

namespace Sis.Alcaldia.Client.Servicios.Implementacion
{
    public class ConfigContabilidadServicio : IConfigContabilidadServicio
    {
        private readonly HttpClient _http;
        public ConfigContabilidadServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<ConfigContabilidadDTO>>> GetAllData()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ConfigContabilidadDTO>>>("api/configcontabilidad/GetAllData");
            return result!;
        }
        public async Task<ResponseDTO<ConfigContabilidadDTO>> Crear(ConfigContabilidadDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/configcontabilidad/Crear", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ConfigContabilidadDTO>>();
            return response!;
        }

        public async Task<bool> Editar(ConfigContabilidadDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/configcontabilidad/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ConfigContabilidadDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var result = await _http.DeleteAsync($"api/configcontabilidad/Eliminar/{Id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<ConfigContabilidadDTO>> ItemId(int Id)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<ConfigContabilidadDTO>>($"api/configcontabilidad/ItemId/{Id}");
            return result!;
        }

    }
}
