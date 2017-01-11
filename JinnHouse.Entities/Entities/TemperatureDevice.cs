using JinnHouse.Entities.Entities;
using JinnHouse.Entities.Interfaces.Interfaces.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities
{
    public abstract class TemperatureDevice : Device, ITemperatureDevice
    {
        public TemperatureDevice()
        {

        }

        public TemperatureDevice(int minTemp, int maxTemp, int temperature)
        {
            this.MinTemperature = minTemp;
            this.MaxTemperature = maxTemp;
            if (!this.SetTemperature(temperature))
            {
                this.Temperature = this.MinTemperature;
            }
        }

        public int Temperature { get; set; }

        public int MaxTemperature { get; protected set; }

        public int MinTemperature { get; protected set; }

        public void IncreaseTemp()
        {
            if (this.IsOn)
            {
                if (this.Temperature < this.MaxTemperature)
                {
                    this.Temperature++;
                }
            }
        }

        public void DecreaseTemp()
        {
            if (this.IsOn)
            {
                if (this.Temperature > this.MinTemperature)
                {
                    this.Temperature--;
                }
            }
        }

        public bool SetTemperature(int temperature)
        {
            if (temperature >= this.MinTemperature && temperature <= this.MaxTemperature)
            {
                this.Temperature = temperature;
                return true;
            }
            return false;
        }
    }
}
