using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClienteApiTest.Services;
using ClienteApiTest.Views;

namespace ClienteApiTest.Controllers
{
    public class AppOrchestrator
    {

        // Instancia única de HttpClient recomendada para evitar agotamiento de sockets
        private static readonly HttpClient _sharedClient = new HttpClient();

        public async Task RunAsync()
        {
            // 1. Lógica de configuración aislada del Main
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string tokenSimulado = ConfigurationManager.AppSettings["SimulationToken"];
            string authStrategy = ConfigurationManager.AppSettings["AuthStrategy"] ?? "Bearer";

            // 2. Construcción del Grafo de Dependencias
            IEquipmentService equipmentService = new EquipmentService(_sharedClient, baseUrl, authStrategy, tokenSimulado);

            // 3. Ejecución del flujo
            Console.WriteLine("\n[Petición] Consultando el endpoint estructurado...");
            var resultado = await equipmentService.GetEquipmentsAsync();

            // 4. Delegación de la presentación
            ConsoleReportView.ImprimirReporteEquipos(resultado);
        }
    }
}
