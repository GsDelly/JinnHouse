using JinnHouse.BLL.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnSports.BLL.Dto
{
    public class DeviceDto : IDeviceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }
    }
}
