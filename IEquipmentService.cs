using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteApiTest.Models;

namespace ClienteApiTest.Services
{
    public interface IEquipmentService
    {
        Task<ApiResponse<EquipmentDto>> GetEquipmentsAsync();
    }
}
