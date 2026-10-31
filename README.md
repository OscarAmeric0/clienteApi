# clienteApiTest
# Cliente Integrador .NET - Reto Técnico

# Cliente Integrador .NET para Consumo de API v3

Este repositorio contiene la solución al reto técnico que consiste en el desarrollo de un cliente ligero construido bajo la plataforma **.NET Framework (C#)**. El propósito principal es el consumo eficiente de endpoints transaccionales en formato JSON, la simulación arquitectónica de políticas de seguridad en la nube y el procesamiento estructurado de las respuestas obtenidas.

## 🚀 Arquitectura y Patrones Técnicos

La implementación del código fuente se ha diseñado siguiendo las mejores prácticas de ingeniería de software para aplicaciones de red:

* **Gestión Centralizada de Conexiones:** Se aplica el patrón de instancia única (`static readonly`) para el objeto `HttpClient`. Esto optimiza la reutilización de conexiones TCP subyacentes y elimina de forma definitiva el riesgo de agotamiento de sockets de red (`Socket Exhaustion`).
* **Parametrización por Entornos:** Toda la información crítica de conectividad, URLs y credenciales se encuentra desacoplada del código fuente mediante el uso del gestor de configuraciones nativo del Framework (`App.config`).
* **Mapeo JSON Elástico:** El procesamiento del payload recibido se delega a la librería `Newtonsoft.Json`. Mediante el uso del tipo dinámico (`dynamic`), el cliente es altamente tolerante al cambio, permitiendo estructurar en consola cualquier evolución del esquema de la API sin requerir modificaciones en la capa de datos.
* **Flujo Defensivo y Tolerancia a Fallos:** Se ha estructurado una arquitectura de captura de excepciones en cascada. Esto permite diferenciar fallos críticos en el canal físico o de transporte (`HttpRequestException`) de fallos lógicos internos del flujo de ejecución de la aplicación.

## 🔐 Simulación del Esquema de Seguridad

De acuerdo con las directrices del enunciado técnico, el cliente simula de manera robusta el flujo de **Client Credentials (OAuth 2.0)**:
1. Las propiedades de acceso son inyectadas en tiempo de ejecución desde el archivo de configuración externa hacia la aplicación.
2. Antes de realizar el despacho de la trama HTTP, la aplicación intercepta los encabezados base para agregar la credencial utilizando la estructura estandarizada de la industria: 
   ```http
   Authorization: Bearer v3-demo-token
   ```
3. Esta inyección replica con precisión milimétrica el comportamiento de la prueba funcional de conectividad solicitada vía comandos de consola:
   ```bash
   curl -X GET "https://avihub.pesoexato.com/api/v3/equipments" -H "Authorization: Bearer v3-demo-token"
   ```

## 📋 Configuración, Compilación y Ejecución

### Prerrequisitos Técnicos
* Microsoft Visual Studio 2022 (o entorno de desarrollo compatible con soporte para soluciones `.sln`).
* .NET Framework 4.8 o superior instalado en el entorno de ejecución.

### Instrucciones para la Puesta en Marcha
1. **Clonación:** Descargue el código fuente clonando este repositorio público en su estación de trabajo local.
2. **Ajuste de Configuración (App.config):** Abra el archivo `App.config` ubicado en la raíz del proyecto y configure los parámetros correspondientes para direccionar las peticiones a la API:
   ```xml
   <appSettings>
       <add key="ApiBaseUrl" value="https://avihub.pesoexato.com/api/v3/" />
       <add key="SimulationToken" value="v3-demo-token" />
   </appSettings>
   ```
3. **Instalación de Dependencias:** Abra la Consola del Administrador de Paquetes NuGet en Visual Studio y ejecute el siguiente comando para resolver las dependencias JSON:
   ```powershell
   Install-Package Newtonsoft.Json
   ```
4. **Referencia del Sistema:** Asegúrese de que el proyecto cuente con la referencia al ensamblado `System.Configuration` (Clic derecho en *Referencias* -> *Agregar referencia* -> Buscar e incorporar `System.Configuration`).
5. **Ejecución:** Compile el proyecto y presione `F5` para iniciar la aplicación de consola. El sistema imprimirá el resumen estructurado e identado de los datos transaccionales obtenidos.

## 🤖 Inventario de Aceleradores de Productividad y Herramientas de IA

Para maximizar los índices de eficiencia durante las fases de andamiaje y documentación, se utilizaron los siguientes componentes de asistencia tecnológica:
* **Modelos de Lenguaje Avanzados (Asistente de IA):** Empleado como acelerador cognitivo para el diseño técnico del flujo de red, la mitigación de errores de resolución de URIs relativas y la redacción estructural de esta documentación técnica.
* **NuGet Package Manager:** Integrado para agilizar la resolución automática de dependencias de terceros.
