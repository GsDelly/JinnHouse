using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.DAL.EFHouseContext;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.DAL.Repositories;
using JinnHouse.Entities.Entities;
using JinnHouse.Entities.Entities.Audio;
using JinnHouse.Entities.Entities.Fan;
using JinnHouse.Entities.Entities.Video;
using JinnHouse.Entities.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.DeviceServices
{
    public class AudioSystemService : IAudioSystemService
    {
        IUnitOfWork Unit { get; set; }

        public AudioSystemService(IUnitOfWork unitOfWork)
        {
            this.Unit = unitOfWork;
        }

        public AudioSystem GetAudioSystemById(int id)
        {
            AudioSystem AudioSystem = this.Unit.GetRepository<AudioSystem>().Get(filter: x => x.Id == id).FirstOrDefault();

            return AudioSystem;
        }

        public IEnumerable<AudioSystem> GetAllAudioSystems()
        {
            IEnumerable<AudioSystem> AudioSystems = this.Unit.GetRepository<AudioSystem>().Get();

            return AudioSystems;
        }

        public void Switch(int id)
        {
            AudioSystem AudioSystem = this.GetAudioSystemById(id);

            if (AudioSystem.IsOn)
            {
                AudioSystem.Off();
            }
            else
            {
                AudioSystem.On();
            }
            this.Unit.SaveChanges();
        }

        public void RemoveAudioSystem(int id)
        {
            this.Unit.GetRepository<AudioSystem>().Delete(this.Unit.GetRepository<AudioSystem>().Get(x => x.Id == id).FirstOrDefault());
            this.Unit.SaveChanges();
        }

        public void AddAudioSystem(string name)
        {
            this.Unit.GetRepository<AudioSystem>().Insert(new AudioSystem(new MusicalSystem(), new VolumeSystem()) { Name = name });
            this.Unit.SaveChanges();
        }

        public bool IsExists(string name)
        {
            if (this.Unit.GetRepository<TV>().Get(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault() != null) return true;
            if (this.Unit.GetRepository<Conditioner>().Get(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault() != null) return true;
            if (this.Unit.GetRepository<Oven>().Get(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault() != null) return true;
            if (this.Unit.GetRepository<AudioSystem>().Get(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault() != null) return true;
            if (this.Unit.GetRepository<Router>().Get(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault() != null) return true;
            return false;
        }
    }
}
