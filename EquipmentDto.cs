using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest
{
    public class EquipmentDto
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("serie")]
        public string Serie { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("relationships")]
        public RelationshipsDto Relationships { get; set; }

        [JsonProperty("timestamps")]
        public TimestampsDto Timestamps { get; set; }
    }
}
