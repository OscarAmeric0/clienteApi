using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest
{
    public class TimeDetailDto
    {
        [JsonProperty("utc")]
        public DateTime Utc { get; set; }

        [JsonProperty("unit_local")]
        public string UnitLocal { get; set; } // Se mapea como string por el formato de zona horaria (-03:00)
    }
}
