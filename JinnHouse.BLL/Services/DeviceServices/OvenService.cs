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
    public class OvenService : IOvenService
    {
        IUnitOfWork Unit { get; set; }

        public OvenService(IUnitOfWork unitOfWork)
        {
            this.Unit = unitOfWork;
        }

        public Oven GetOvenById(int id)
        {
            Oven Oven = this.Unit.GetRepository<Oven>().Get(filter: x => x.Id == id).FirstOrDefault();

            return Oven;
        }

        public IEnumerable<Oven> GetAllOvens()
        {
            IEnumerable<Oven> Ovens = this.Unit.GetRepository<Oven>().Get();

            return Ovens;
        }

        public void Switch(int id)
        {
            Oven Oven = this.GetOvenById(id);

            if (Oven.IsOn)
            {
                Oven.Off();
            }
            else
            {
                Oven.On();
            }
            this.Unit.SaveChanges();
        }

        public void RemoveOven(int id)
        {
            this.Unit.GetRepository<Oven>().Delete(this.Unit.GetRepository<Oven>().Get(x => x.Id == id).FirstOrDefault());
            this.Unit.SaveChanges();
        }

        public void AddOven(string name)
        {
            this.Unit.GetRepository<Oven>().Insert(new Oven() { Name = name });
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

        public void SwitchModeForward(int id)
        {
            var oven = this.GetOvenById(id);

            oven.OvenModeForward();

            this.Unit.SaveChanges();
        }

        public void SwitchModeBackward(int id)
        {
            var oven = this.GetOvenById(id);

            oven.OvenModeBackward();

            this.Unit.SaveChanges();
        }
    }
}
