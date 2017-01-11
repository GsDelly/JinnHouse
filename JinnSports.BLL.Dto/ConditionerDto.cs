using JinnHouse.BLL.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnSports.BLL.Dto
{
    public class ConditionerDto : DeviceDto, IConditionerDto
    {
        public int Temperature { get; set; }

        public int MinTemperature { get; }

        public int MaxTemperature { get; }

        public string FanSpeed { get; set; }
    }
}
