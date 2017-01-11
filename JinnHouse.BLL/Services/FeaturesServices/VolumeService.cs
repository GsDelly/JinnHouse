using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Entities.Audio;
using JinnHouse.Entities.Entities.Video;
using JinnHouse.Entities.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.FeaturesServices
{
    public class VolumeService : IVolumeService
    {
        public IUnitOfWork Unit { get; set; }

        public VolumeService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public void VolumeDown(string name)
        {
            IVolumeDevice volume = this.GetVolumeDevice(name);

            if (volume.IsOn)
            {
                volume.VolumeSystem.VolumeDown();
                this.Unit.SaveChanges();
            }
        }

        public void VolumeUp(string name)
        {
            IVolumeDevice volume = this.GetVolumeDevice(name);

            if (volume.IsOn)
            {
                volume.VolumeSystem.VolumeUp();

                this.Unit.SaveChanges();
            }
        }

        public void Mute(string name)
        {
            IVolumeDevice volume = this.GetVolumeDevice(name);

            if (volume.IsOn)
            {
                volume.VolumeSystem.Mute();

                this.Unit.SaveChanges();
            }
        }

        public IVolumeDevice GetVolumeDevice(string name)
        {
            IVolumeDevice volume;

            if ((volume = this.Unit.GetRepository<AudioSystem>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return volume;
            }
            if ((volume = this.Unit.GetRepository<TV>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return volume;
            }

            return default(IVolumeDevice);
        }
    }
}
