using JinnHouse.BLL.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnSports.BLL.Dto
{
    public class OvenDto : DeviceDto, IOvenDto
    {
        public string OvenMode { get; set; }

        public int Temperature { get; set; }

        public int MinTemperature { get; }

        public int MaxTemperature { get; }
    }
}
