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

namespace JinnHouse.BLL.Services
{
    public class TvService : ITvService
    {
        public IUnitOfWork Unit { get; set; }

        public TvService(IUnitOfWork unitOfWork)
            {
                this.Unit = unitOfWork;
            }

        public TV GetTvById(int id)
            {
                TV Tv = this.Unit.GetRepository<TV>().Get(filter: x => x.Id == id).FirstOrDefault();

                return Tv;
            }

        public IEnumerable<TV> GetAllTvs()
            {
                IEnumerable<TV> TVs = this.Unit.GetRepository<TV>().Get();

                return TVs;
            }

        public void Switch(int id)
            {
                TV Tv = this.GetTvById(id);

                if (Tv.IsOn)
                {
                    Tv.Off();
                }
                else
                {
                    Tv.On();
                }
                this.Unit.SaveChanges();
            }

        public void RemoveTv(int id)
            {
                this.Unit.GetRepository<TV>().Delete(this.Unit.GetRepository<TV>().Get(x => x.Id == id).FirstOrDefault());
                this.Unit.SaveChanges();
            }

        public void AddTv(string name)
            {
                this.Unit.GetRepository<TV>().Insert(new TV(new ChannelSystem(), new VolumeSystem(), new BrightSystem()) { Name = name });
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
