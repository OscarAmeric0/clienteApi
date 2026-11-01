using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClienteApiTest.Models;
using ClienteApiTest.Services;
using Newtonsoft.Json;

namespace ClienteApiTest.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly HttpClient _httpClient;

        // Pasamos los parámetros leídos desde el App.config
        public EquipmentService(HttpClient httpClient, string baseUrl, string authStrategy, string token)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            // Aseguramos que la BaseAddress termine en '/' para que HttpClient no descarte segmentos
            
            if (!baseUrl.EndsWith("/")) baseUrl += "/";
            _httpClient.BaseAddress = new Uri(baseUrl);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Usamos dinámicamente el AuthStrategy de tu .config (ej. "Bearer")
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authStrategy, token);
        }

        public async Task<ApiResponse<EquipmentDto>> GetEquipmentsAsync()
        {
            // OJO: "equipments" va SIN barra inicial porque la BaseAddress ya termina en "v3/"
            // Esto resolverá correctamente a: https://pesoexato.com
            HttpResponseMessage response = await _httpClient.GetAsync("equipments");

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<EquipmentDto>>(jsonResponse);
            }

            string errorDetail = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Error {response.StatusCode}: {errorDetail}");
        }
    }
}
