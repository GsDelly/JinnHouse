using JinnHouse.Entities.Entities;
using JinnHouse.Entities.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Audio
{
    public abstract class MusicalDevice : Device, IAudioDevice, IVolumeDevice
    {
        private const int minVolume = 0;
        private const int volume = 15;
        private const int maxVolume = 100;

        public MusicalDevice()
        {

        }

        public MusicalDevice(IVolumeSystem volumeSystem)
        {
            this.VolumeSystem = (VolumeSystem)volumeSystem;
            this.VolumeSystem.Volume = volume;
            this.VolumeSystem.MaxVolume = maxVolume;
            this.VolumeSystem.MinVolume = minVolume;
        }

        public virtual VolumeSystem VolumeSystem { get; set; }

        public bool IsMusicOn { get; set; }

        IVolumeSystem IVolumeDevice.VolumeSystem
        {
            get
            {
                return (IVolumeSystem)this.VolumeSystem;
            }

            set
            {
                if (!(value is IVolumeSystem))
                    throw new InvalidCastException("must implement IBrightSystem");

                this.VolumeSystem = (VolumeSystem)value;
            }
        }

        public void MusicOn()
        {
            this.IsMusicOn = true;
        }

        public void MusicOff()
        {
            this.IsMusicOn = false;
        }
    }
}
