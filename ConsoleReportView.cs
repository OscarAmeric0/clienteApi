using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteApiTest.Models;

namespace ClienteApiTest.Views
{
    public static class ConsoleReportView
    {
        public static void ImprimirReporteEquipos(ApiResponse<EquipmentDto> resultado)
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

                if (equipo.Relationships != null)
                {
                    Console.WriteLine($"  --> RELACIONES Y UBICACIÓN:");
                    Console.WriteLine($"      ID Núcleo   : {equipo.Relationships.NucleiId} (Número: {equipo.Relationships.NucleiNumber})");
                    Console.WriteLine($"      Número Lote : {equipo.Relationships.BatchNumber}");
                    Console.WriteLine($"      Ubicación   : {equipo.Relationships.SideName}");
                }

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
