using JinnHouse.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JinnHouse.Entities.Interfaces.Interfaces.Video;
using JinnHouse.Entities.Interfaces.Interfaces;
using JinnHouse.Entities.Enums.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace JinnHouse.Entities.Entities.Video
{
    public class TV : Device, IChannelDevice, IBrightDevice,
        IVolumeDevice
    {
        private const int MinVolume = 0;
        private const int MaxVolume = 100;
        private int volume = 15;

        public virtual VolumeSystem VolumeSystem { get; set; }

        public virtual ChannelSystem ChannelSystem { get; set; }

        public virtual BrightSystem BrightSystem { get; set; }

        IVolumeSystem IVolumeDevice.VolumeSystem
        {
            get
            {
                return (IVolumeSystem)this.VolumeSystem;
            }

            set
            {
                if (!(value is IVolumeSystem))
                    throw new InvalidCastException("must implement IVolumeSystem");

                this.VolumeSystem = (VolumeSystem)value;
            }
        }

        public TV()
        {

        }

        public TV(IChannelSystem channelSystem, IVolumeSystem volumeSystem, IBrightSystem brightSystem)
        {
            this.ChannelSystem = (ChannelSystem)channelSystem;
            this.VolumeSystem = (VolumeSystem)volumeSystem;
            this.BrightSystem = (BrightSystem)brightSystem;

            this.VolumeSystem.Volume = this.volume;
            this.VolumeSystem.MinVolume = 0;
            this.VolumeSystem.MaxVolume = 100;

            this.BrightSystem.BrightLevel = BrightLevel.Medium;
        }

        IChannelSystem IChannelDevice.ChannelSystem
        {
            get
            {
                return (IChannelSystem)this.ChannelSystem;
            }

            set
            {
                if (!(value is IChannelSystem))
                    throw new InvalidCastException("must implement IChannelSystem");

                this.ChannelSystem = (ChannelSystem)value;
            }
        }

        IBrightSystem IBrightDevice.BrightSystem
        {
            get
            {
                return (IBrightSystem)this.BrightSystem;
            }

            set
            {
                if (!(value is IBrightSystem))
                    throw new InvalidCastException("must implement IBrightSystem");

                this.BrightSystem = (BrightSystem)value;
            }
        }

        public override string ToString()
        {
            string condition = string.Format(
                "{0}: {1} Current Channel: {2}, Volume Level: {3}, Brightness: {4}",
                this.Name,
                this.IsOn ? "On" : "Off",
                this.ChannelSystem.CurrentChannel,
                this.VolumeSystem.Volume);

            return condition;
        }
    }
}
