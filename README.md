# clienteApi
# Cliente Integrador .NET - Reto Técnico

Este proyecto consiste en un cliente ligero desarrollado en **.NET Framework (C#)** diseñado para consumir e integrar las respuestas transaccionales en formato JSON expuestas por la API v3 de AviHub.

## 🚀 Estrategia de Seguridad Adoptada

Siguiendo las especificaciones del reto técnico y alineándonos con el entorno de pruebas (`curl`), se seleccionó e implementó el enfoque de **Client Credentials (OAuth 2.0)**:
* Se lee de forma dinámica un token de acceso simulado parametrizado desde el archivo de configuración global (`App.config`).
* Se inyecta automáticamente el encabezado de autenticación estándar `Authorization: Bearer v3-demo-token` antes de cada invocación HTTP.

## 🛠️ Patrón de Arquitectura y Herramientas

* **HttpClient centralizado:** Se utiliza una instancia única y estática de `HttpClient` para evitar problemas de agotamiento de sockets de red y mejorar el rendimiento de las peticiones concurrentes.
* **Manejo de Respuestas Transaccionales:** Procesamiento y formateo de estructuras JSON mediante la integración de la librería `Newtonsoft.Json`.
* **Robustez y Tolerancia a Fallos:** Bloques estructurados de control de excepciones (`try-catch`) especializados en capturar errores HTTP específicos de red (`HttpRequestException`) y fallos globales del sistema.

## 📋 Instrucciones de Compilación y Ejecución

### Prerrequisitos
* Visual Studio 2022 (o superior) con la carga de trabajo de desarrollo de escritorio de .NET.
* .NET Framework instalado.

### Pasos para Ejecutar
1. Clonar este repositorio en tu máquina local.
2. Abrir el archivo de solución `ClienteApiTest.sln` en Visual Studio.
3. Asegurarse de restaurar los paquetes NuGet si el IDE no lo hace automáticamente (Clic derecho en la solución -> *Restaurar paquetes NuGet*).
4. Presionar `F5` o el botón **Iniciar** en Visual Studio para compilar y ejecutar la aplicación de consola.

## 🤖 Inventario de Herramientas de IA y Skills Utilizados

Para acelerar el desarrollo del código base, el análisis estructurado de los requerimientos y el diseño técnico se utilizaron:
* **Modelos de Lenguaje Avanzados (Asistente de IA):** Para el andamiaje del cliente HTTP, la adaptación arquitectónica de configuraciones clásicas (`App.config`) y la redacción técnica de esta documentación.
* **NuGet Package Manager:** Para la resolución expedita de dependencias JSON.
