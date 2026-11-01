using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("pagination")]
        public PaginationDto Pagination { get; set; }
    }

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

    public class RelationshipsDto
    {
        [JsonProperty("nuclei_id")]
        public int NucleiId { get; set; }

        [JsonProperty("nuclei_number")]
        public int NucleiNumber { get; set; }

        [JsonProperty("batch_number")]
        public string BatchNumber { get; set; }

        [JsonProperty("side_name")]
        public string SideName { get; set; }
    }

    public class TimestampsDto
    {
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("last_connection")]
        public ConnectionDetailDto LastConnection { get; set; }
    }

    public class ConnectionDetailDto
    {
        [JsonProperty("utc")]
        public DateTime Utc { get; set; }

        [JsonProperty("unit_local")]
        public DateTimeOffset UnitLocal { get; set; }
    }

    public class PaginationDto
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("total_records")]
        public int TotalRecords { get; set; }
    }
}
