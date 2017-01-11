using JinnHouse.Entities.Enums.Enums;
using JinnHouse.Entities.Interfaces.Interfaces.Fan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Fan
{
    public class Conditioner : TemperatureDevice, IFanDevice
    {
        private static int fanSpeedMin = 0;
        private static int fanSpeedMax = 50;
       
        public virtual FanSystem FanSystem { get; set; }

        IFanSystem IFanDevice.FanSystem
        {
            get
            {
                return this.FanSystem;
            }

            set
            {
                if (!(value is IFanSystem))
                    throw new InvalidCastException("must implement IFanSystem");

                this.FanSystem = (FanSystem)value;
            }
        }

        //public IFanSystem FanSystem { get; set; }
        public Conditioner()
        {

        }

        public Conditioner(int temperature, IFanSystem fanSystem) : base(fanSpeedMin, fanSpeedMax, temperature)
        {
            this.FanSystem = (FanSystem)fanSystem;
        }

        public Conditioner(IFanSystem fanSystem) : this(Convert.ToInt32((fanSpeedMax - fanSpeedMin) / 2), fanSystem)
        {
        }

        public override string ToString()
        {
            string condition = string.Format(
                "{0}: {1}, Current Temmperature: {2}, {3}",
                this.Name,
                this.IsOn ? "On" : "Off",
                this.Temperature,
                this.FanSystem.FanSpeed.GetDescription());

            return condition;
        }
    }
}
