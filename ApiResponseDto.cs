using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClienteApiTest
{
    public class ApiResponseDto
    {
        [JsonProperty("data")]
        public List<EquipmentDto> Data { get; set; }

        [JsonProperty("pagination")]
        public PaginationDto Pagination { get; set; }
    }
}
