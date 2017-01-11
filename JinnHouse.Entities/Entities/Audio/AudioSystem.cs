using JinnHouse.Entities.Entities.Audio;
using JinnHouse.Entities.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Audio
{
    public class AudioSystem : MusicalDevice, IMusicDevice
    {
        private int volume = 15;

        public virtual MusicalSystem MusicalSystem { get; set; }

        IMusicSystem IMusicDevice.MusicSystem
        {
            get
            {
                return (IMusicSystem)this.MusicalSystem;
            }

            set
            {
                if (!(value is IMusicSystem))
                    throw new InvalidCastException("must implement IMusicSystem");

                this.MusicalSystem = (MusicalSystem)value;
            }
        }

        public AudioSystem() : base()
        {

        }

        public AudioSystem(IMusicSystem musicSystem, IVolumeSystem volumeSystem) : base(volumeSystem)
        {
            this.MusicalSystem = (MusicalSystem)musicSystem;
            this.MusicalSystem.Songs = this.MusicalSystem.GetDefaultSongs();
            this.MusicalSystem.CurrentSong = this.MusicalSystem.Songs.First().ToString();
            this.VolumeSystem.Volume = this.volume;
        }

        //public IMusicSystem MusicSystem { get; set; } 

        public override string ToString()
        {
            string condition = string.Format(
                "{0}: {1} Current Song: {2}, Volume Level: {3}",
                this.Name,
                this.IsOn ? "On" : "Off",
                this.MusicalSystem.CurrentSong,
                this.VolumeSystem.Volume);

            return condition;
        }

    }
}
