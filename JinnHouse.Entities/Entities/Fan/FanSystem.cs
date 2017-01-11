using JinnHouse.Entities.Enums.Enums;
using JinnHouse.Entities.Interfaces.Interfaces.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Fan
{
    public class FanSystem : IFanSystem
    {
        public FanSystem()
        {

        }

        public int FanSystemId { get; set; }

        public FanSpeed FanSpeed { get; set; }

        public void SpeedUp()
        {
            if ((int)this.FanSpeed < Enum.GetValues(typeof(FanSpeed)).Length - 1)
            {
                this.FanSpeed++;
            }
        }

        public void SpeedDown()
        {
            if ((int)this.FanSpeed > 0)
            {
                this.FanSpeed--;
            }
        }
    }
}
