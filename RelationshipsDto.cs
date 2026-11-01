using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest
{
    public class RelationshipsDto
    {
        [JsonProperty("nuclei_id")]
        public int NucleiId { get; set; }

        [JsonProperty("nuclei_number")]
        public int NucleiNumber { get; set; }

        [JsonProperty("batch_id")]
        public int BatchId { get; set; }

        [JsonProperty("batch_number")]
        public string BatchNumber { get; set; }

        [JsonProperty("sector_id")]
        public int SectorId { get; set; }

        [JsonProperty("sector_number")]
        public int SectorNumber { get; set; }

        [JsonProperty("side_id")]
        public int SideId { get; set; }

        [JsonProperty("side_name")]
        public string SideName { get; set; }

        [JsonProperty("side_box_id")]
        public int SideBoxId { get; set; }

        [JsonProperty("side_box_number")]
        public string SideBoxNumber { get; set; } // Viene como string "1" en el JSON
    }
}
