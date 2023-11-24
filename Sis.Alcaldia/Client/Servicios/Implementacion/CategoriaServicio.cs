using Sis.Alcaldia.Client.Servicios.Contratos;
using Sis.Alcaldia.Shared.Models;
using System.Net.Http.Json;

namespace Sis.Alcaldia.Client.Servicios.Implementacion
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly HttpClient _http;
        public CategoriaServicio(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/categoria/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return response!;
        }

        public async Task<bool> Editar(CategoriaDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/categoria/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/categoria/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>("api/categoria/Lista");
            return result!;
        }
    }
}
