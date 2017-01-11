using JinnHouse.Entities.Enums.Enums;
using JinnHouse.Entities.Interfaces.Interfaces.Oven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities
{
    public class Oven : TemperatureDevice, IOvenDevice
    {
        public Oven(int minTemperature, int maxTemperature, int temperature) : 
            base(minTemperature, maxTemperature, temperature)
        {
        }

        public Oven() : this(20, 100, 35)
        {
            this.OvenMode = OvenModes.Normal;
        }

        public OvenModes OvenMode { get; set; }

        public void OvenModeForward()
        {
            if ((int)this.OvenMode < Enum.GetValues(typeof(OvenModes)).Length - 1)
            {
                this.OvenMode++;
            }
        }

        public void OvenModeBackward()
        {
            if ((int)this.OvenMode > 0)
            {
                this.OvenMode--;
            }
        }

        public override string ToString()
        {
                string condition = string.Format(
                    "{0}: {1}, Current temperature :{2}",
                    this.Name,
                    this.IsOn ? "On" : "Off",
                    this.Temperature);
                return condition;
        }
    }
}
