using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using ClienteApiTest.Services;
using ClienteApiTest.Models;


namespace ClienteApiTest
{
    internal class Program
    {// Instancia única de HttpClient recomendada para evitar agotamiento de sockets
        private static readonly HttpClient sharedClient = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Iniciando Cliente Integrador (.NET 4.7.2) ===");

            try
            {
                // El Main solo instancia el orquestador y arranca la aplicación
                var app = new AppOrchestrator();
                await app.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error Crítico del Sistema] {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

    }
}
