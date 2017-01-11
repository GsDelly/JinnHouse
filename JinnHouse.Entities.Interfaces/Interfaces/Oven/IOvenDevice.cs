using JinnHouse.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinnHouse.Entities.Enums.Enums;
using JinnHouse.Entities.Interfaces.Interfaces.Temperature;

namespace JinnHouse.Entities.Interfaces.Interfaces.Oven
{
    public interface IOvenDevice : ITemperatureDevice
    {
        OvenModes OvenMode { get; set; }

        void OvenModeForward();

        void OvenModeBackward();
    }
}
