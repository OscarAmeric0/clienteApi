using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest
{
    public class TimestampsDto
    {
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("updated_at")]
        public TimeDetailDto UpdatedAt { get; set; }

        [JsonProperty("last_connection")]
        public TimeDetailDto LastConnection { get; set; }

        [JsonProperty("last_upload")]
        public TimeDetailDto LastUpload { get; set; }
    }
}
}
