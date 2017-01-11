using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinnHouse.Entities.Interfaces.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JinnHouse.Entities.Entities
{
    public abstract class Device : ISwitchable, IDevice
    {
        public Device()
        {
            this.IsOn = true;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public void On()
        {
            this.IsOn = true;
        }

        public void Off()
        {
            this.IsOn = false;
        }
    }
}
