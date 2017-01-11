using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinnHouse.Entities.Interfaces.Interfaces.Temperature;
using JinnHouse.Entities.Enums.Enums;

namespace JinnHouse.Entities.Interfaces.Interfaces.Fan
{
    public interface IFanDevice : ITemperatureDevice
    {
        IFanSystem FanSystem { get; set; }
    }
}
