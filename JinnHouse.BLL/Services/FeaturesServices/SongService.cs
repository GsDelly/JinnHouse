using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Entities.Audio;
using JinnHouse.Entities.Interfaces.Interfaces.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.FeaturesServices
{
    public class SongService : ISongService
    {
        public IUnitOfWork Unit { get; set; }

        public SongService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public void PreviousSong(string name)
        {
            IMusicDevice musicDevice = this.GetMusicalDevice(name);

            if (musicDevice.IsOn)
            {
                musicDevice.MusicSystem.SwitchBackward();

                this.Unit.SaveChanges();
            }
        }

        public void NextSong(string name)
        {
            IMusicDevice musicDevice = this.GetMusicalDevice(name);

            if (musicDevice.IsOn)
            {
                musicDevice.MusicSystem.SwitchForward();

                this.Unit.SaveChanges();
            }
        }

        public IMusicDevice GetMusicalDevice(string name)
        {
            IMusicDevice Song;

            if ((Song = this.Unit.GetRepository<AudioSystem>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return Song;
            }

            return default(IMusicDevice);
        }
    }
}
