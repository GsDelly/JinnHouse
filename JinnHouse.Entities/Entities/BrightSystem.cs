using JinnHouse.Entities.Enums.Enums;
using JinnHouse.Entities.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities
{
    public class BrightSystem : IBrightSystem
    {
        public int BrightId { get; set; }

        public BrightLevel BrightLevel { get; set; }

        public void BrightUp()
        {
            if ((int)this.BrightLevel < Enum.GetValues(typeof(BrightLevel)).Length - 1)
            {
                this.BrightLevel++;
            }
        }

        public void BrightDown()
        {
            if ((int)this.BrightLevel > 0)
            {
                this.BrightLevel--;
            }
        }
    }
}
