using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;


namespace ClienteApiTest
{
    internal class Program
    {// Instancia única de HttpClient recomendada para evitar agotamiento de sockets
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Iniciando Cliente Integrador .NET ===");

            // 1. Cargar configuraciones del App.config
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "https://pesoexato.com";
            string tokenSimulado = ConfigurationManager.AppSettings["SimulationToken"] ?? "v3-demo-token";

            try
            {
                // 2. Configurar el HttpClient Base
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // 3. Simulación de Seguridad: Inyección del Bearer Token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenSimulado);
                Console.WriteLine($"[Seguridad] Bearer Token simulado inyectado correctamente.");

                // 4. Consumir el recurso 'equipments' de forma absoluta
                Console.WriteLine("\n[Petición] Invocando endpoint: https://avihub.pesoexato.com/api/v3/equipments ...");
                // Al pasarle la URL completa con el string de configuración, evitamos errores de resolución de rutas
                HttpResponseMessage response = await client.GetAsync(baseUrl + "equipments");

                

                // 5. Procesar la respuesta transaccional
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("[Respuesta] JSON recibido con éxito.");

                    // Deserializar usando Newtonsoft.Json
                    // Nota: Usamos 'dynamic' temporalmente para adaptarnos a cualquier estructura JSON que devuelva la API
                    dynamic equipos = JsonConvert.DeserializeObject(jsonResponse);

                    Console.WriteLine("\n=== RESUMEN ESTRUCTURADO DE EQUIPOS ===");
                    Console.WriteLine(JsonConvert.SerializeObject(equipos, Formatting.Indented));
                }
                else
                {
                    Console.WriteLine($"\n[Error] La API respondió con código de estado: {response.StatusCode} ({(int)response.StatusCode})");
                    string errorDetail = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(errorDetail))
                    {
                        Console.WriteLine($"Detalle del error: {errorDetail}");
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"\n[Error de Red] No se pudo conectar con la API: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error Inesperado] Ocurrió un fallo en la aplicación: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
