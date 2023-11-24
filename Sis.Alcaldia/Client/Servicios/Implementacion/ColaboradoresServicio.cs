using Sis.Alcaldia.Client.Servicios.Contratos;
using Sis.Alcaldia.Shared.Models;
using Sis.Alcaldia.Shared.Models.Colaboradores;
using System.Net.Http.Json;

namespace Sis.Alcaldia.Client.Servicios.Implementacion
{
    public class ColaboradoresServicio : IColaboradoresServicio
    {

        private readonly HttpClient _http;
        public ColaboradoresServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<ColaboradoresDTO>> Crear(ColaboradoresDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/colaboradores/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ColaboradoresDTO>>();
            return response!;
        }
        public async Task<bool> Editar(ColaboradoresDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/colaboradores/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ColaboradoresDTO>>();

            return response!.status;
        }
        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/colaboradores/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }
        public async Task<ResponseDTO<List<ColaboradoresDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ColaboradoresDTO>>>("api/colaboradores/Lista");
            return result!;
        }
        
        public async Task<ResponseDTO<ColaboradoresDTO>> Obtener(int IdColaborador)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<ColaboradoresDTO>>($"api/colaboradores/Obtener/{IdColaborador}");
            return result!;
        }
        //detalle

        public async Task<ResponseDTO<List<ColaboradoresDTO>>> GetAllData()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ColaboradoresDTO>>>("api/colaboradores/GetAllData");
            return result!;
        }
        public async Task<ResponseDTO<List<ColaboradoresDTO>>> GetColFac(int IdColaborador)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ColaboradoresDTO>>>($"api/colaboradores/GetColFac/{IdColaborador}");
            return result!;
        }

        public async Task<ResponseDTO<List<ColaboradoresDTO>>> GetColFactPag(int IdColaborador, int IdFactura)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ColaboradoresDTO>>>($"api/colaboradores/GetColFactPag/{IdColaborador}/{IdFactura}");
            return result!;
        }

        //Facturas
        public async Task<ResponseDTO<ConfigContabilidadDTO>> ConfigConta()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<ConfigContabilidadDTO>>("api/colaboradores/ConfigConta");
            return result!;
        }

        public async Task<ResponseDTO<FacturasDTO>> CrearFacturas(FacturasDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/colaboradores/CrearFacturas", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<FacturasDTO>>();
            return response!;
        }

        public async Task<bool> EditarFacturas(FacturasDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/colaboradores/EditarFacturas", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<FacturasDTO>>();

            return response!.status;
        }

        public async Task<bool> EliminarFacturas(int id)
        {
            var result = await _http.DeleteAsync($"api/colaboradores/EliminarFacturas/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }
        //Pagos
        public async Task<ResponseDTO<PagosDTO>> CrearPagos(PagosDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/colaboradores/CrearPagos", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<PagosDTO>>();
            return response!;
        }
        public async Task<bool> EditarPagos(PagosDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/colaboradores/EditarPagos", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<PagosDTO>>();

            return response!.status;
        }
        public async Task<bool> EliminarPagos(int id)
        {
            var result = await _http.DeleteAsync($"api/colaboradores/EliminarPagos/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }
        public async Task<ResponseDTO<PagosDTO>> ListaPagos(int IdFact)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<PagosDTO>>($"api/colaboradores/ListaPagos/{IdFact}");
            return result!;
        }
       
    }
}
