using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest
{
    public class AviHubClient : IAviHubClient
    {
        private readonly HttpClient _httpClient;

        // Se inyecta automáticamente el HttpClient gestionado por HttpClientFactory
        public AviHubClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EquipmentDto>> GetApiResponseAsync()
        {
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "https://avihub.pesoexato.com/api/v3/";

            // Consumo del recurso de forma segura mediante la ruta combinada
            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + "equipments");

            if (!response.IsSuccessStatusCode)
            {
                string errorDetail = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Código de estado: {response.StatusCode} ({(int)response.StatusCode}). Detalle: {errorDetail}");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialización con tipado fuerte mediante nuestro DTO
            return JsonConvert.DeserializeObject<List<EquipmentDto>>(jsonResponse);
        }
    }
}
