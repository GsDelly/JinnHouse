using JinnHouse.Entities.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities
{
    public class VolumeSystem : IVolumeSystem
    {
        public virtual int Volume { get; set; }
        public virtual int MinVolume { get; set; }
        public virtual int MaxVolume { get; set; }

        public int VolumeSystemId { get; set; }

        public void Mute()
        {
            this.Volume = MinVolume;
        }

        public void VolumeUp()
        {
            if (this.Volume < MaxVolume)
            {
                this.Volume++;
            }
        }

        public void VolumeDown()
        {
            if (this.Volume > MinVolume)
            {
                this.Volume--;
            }
        }
    }
}
