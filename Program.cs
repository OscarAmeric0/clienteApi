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

            // 1. Leer directamente los valores exactos de tu App.config
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string tokenSimulado = ConfigurationManager.AppSettings["SimulationToken"];
            string authStrategy = ConfigurationManager.AppSettings["AuthStrategy"] ?? "Bearer";

            // 2. Inyectar configuraciones al Servicio Arquitectónico
            IEquipmentService equipmentService = new EquipmentService(sharedClient, baseUrl, authStrategy, tokenSimulado);

            try
            {
                Console.WriteLine("\n[Petición] Consultando el endpoint estructurado...");
                var resultado = await equipmentService.GetEquipmentsAsync();
                // 3. Llamada al método especializado para imprimir los datos
                ImprimirReporteEquipos(resultado);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error] {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }



        /// <summary>
        /// Método independiente encargado exclusivamente de dar formato y mostrar los datos en consola.
        /// </summary>
        private static void ImprimirReporteEquipos(ApiResponse<EquipmentDto> resultado)
        {
            if (resultado?.Data == null || resultado.Data.Count == 0)
            {
                Console.WriteLine("\n[Aviso] No se recibieron datos de equipos para mostrar.");
                return;
            }

            Console.WriteLine("\n=== DETALLE COMPLETO Y ESTRUCTURADO DE EQUIPOS (Tipado con DTOs) ===");

            for (int i = 0; i < resultado.Data.Count; i++)
            {
                EquipmentDto equipo = resultado.Data[i];

                Console.WriteLine($"\n==================================================");
                Console.WriteLine($"[Equipo {i + 1}] ID: {equipo.Id}");
                Console.WriteLine($"--------------------------------------------------");
                Console.WriteLine($"  Descripción  : {equipo.Description}");
                Console.WriteLine($"  Modelo       : {equipo.Model}");
                Console.WriteLine($"  Serie        : {equipo.Serie}");
                Console.WriteLine($"  Versión      : {equipo.Version}");
                Console.WriteLine($"  Género/Tipo  : {equipo.Gender}");
                Console.WriteLine($"  Estado       : {equipo.Status}");

                // Renderizado de Relaciones
                if (equipo.Relationships != null)
                {
                    Console.WriteLine($"  --> RELACIONES Y UBICACIÓN:");
                    Console.WriteLine($"      ID Núcleo   : {equipo.Relationships.NucleiId} (Número: {equipo.Relationships.NucleiNumber})");
                    Console.WriteLine($"      Número Lote : {equipo.Relationships.BatchNumber}");
                    Console.WriteLine($"      Ubicación   : {equipo.Relationships.SideName}");
                }

                // Renderizado de Marcas de Tiempo
                if (equipo.Timestamps != null)
                {
                    Console.WriteLine($"  --> MARCAS DE TIEMPO:");
                    Console.WriteLine($"      Zona Horaria: {equipo.Timestamps.TimeZone}");

                    if (equipo.Timestamps.LastConnection != null)
                    {
                        Console.WriteLine($"      Última Conexión (UTC)  : {equipo.Timestamps.LastConnection.Utc:yyyy-MM-dd HH:mm:ss}");
                        Console.WriteLine($"      Última Conexión (Local): {equipo.Timestamps.LastConnection.UnitLocal:yyyy-MM-dd HH:mm:ss zzz}");
                    }
                }
            }

            // Renderizado de Paginación Global
            if (resultado.Pagination != null)
            {
                Console.WriteLine($"\n==================================================");
                Console.WriteLine($"=== RESUMEN DE PAGINACIÓN ===");
                Console.WriteLine($"Página Actual    : {resultado.Pagination.CurrentPage}");
                Console.WriteLine($"Total Registros  : {resultado.Pagination.TotalRecords}");
                Console.WriteLine($"==================================================");
            }
        }

    }
}
