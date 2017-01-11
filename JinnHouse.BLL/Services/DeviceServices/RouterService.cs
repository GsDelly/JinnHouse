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
    public class RouterService : IRouterService
    {
        IUnitOfWork Unit { get; set; }

        public RouterService(IUnitOfWork unitOfWork)
        {
            this.Unit = unitOfWork;
        }

        public Router GetRouterById(int id)
        {
            Router router = this.Unit.GetRepository<Router>().Get(filter: x => x.Id == id).FirstOrDefault();

            return router;
        }

        public IEnumerable<Router> GetAllRouters()
        {
                IEnumerable<Router> routers = this.Unit.GetRepository<Router>().Get();

                return routers;
        }

        public void Switch(int id)
        {
                Router router = this.GetRouterById(id);

                if (router.IsOn)
                {
                    router.Off();
                }
                else
                {
                    router.On();
                }
                this.Unit.SaveChanges();
        }

        public void SwitchConnecton(int id)
        {
                Router router = this.GetRouterById(id);

                if (router.IsConnected)
                {
                    router.Disconnect();
                }
                else
                {
                    router.Connect();
                }
                this.Unit.SaveChanges();
        }

        public void RemoveRouter(int id)
        {
                this.Unit.GetRepository<Router>().Delete(this.Unit.GetRepository<Router>().Get(x=> x.Id == id).FirstOrDefault());
                this.Unit.SaveChanges();
        }

        public void AddRouter(string name)
        {
                this.Unit.GetRepository<Router>().Insert(new Router() { Name = name });
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
