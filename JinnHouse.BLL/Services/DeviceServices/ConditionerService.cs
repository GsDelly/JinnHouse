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
    public class ConditionerService : IConditionerService
    {
        IUnitOfWork Unit { get; set; }

        public ConditionerService(IUnitOfWork unitOfWork)
        {
            this.Unit = unitOfWork;
        }

        public Conditioner GetConditionerById(int id)
        {
            Conditioner Conditioner = this.Unit.GetRepository<Conditioner>().Get(filter: x => x.Id == id).FirstOrDefault();

            return Conditioner;
        }

        public IEnumerable<Conditioner> GetAllConditioners()
        {
            IEnumerable<Conditioner> Conditioners = this.Unit.GetRepository<Conditioner>().Get();

            return Conditioners;
        }

        public void Switch(int id)
        {
            Conditioner Conditioner = this.GetConditionerById(id);

            if (Conditioner.IsOn)
            {
                Conditioner.Off();
            }
            else
            {
                Conditioner.On();
            }
            this.Unit.SaveChanges();
        }

        public void RemoveConditioner(int id)
        {
            this.Unit.GetRepository<Conditioner>().Delete(this.Unit.GetRepository<Conditioner>().Get(x => x.Id == id).FirstOrDefault());
            this.Unit.SaveChanges();
        }

        public void AddConditioner(string name)
        {
            this.Unit.GetRepository<Conditioner>().Insert(new Conditioner(new FanSystem()) { Name = name });
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
