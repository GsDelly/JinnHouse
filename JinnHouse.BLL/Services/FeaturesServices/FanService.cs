using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.EFHouseContext;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.DAL.Repositories;
using JinnHouse.Entities.Entities.Fan;
using JinnHouse.Entities.Interfaces.Interfaces.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.FeaturesServices
{
    public class FanService : IFanService
    {
        public IUnitOfWork Unit { get; set; }

        public FanService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public void SpeedDown(string name)
        {
            IFanDevice fan = this.GetFanDevice(name);

            if (fan.IsOn)
            {
                fan.FanSystem.SpeedDown();

                this.Unit.SaveChanges();
            }
        }

        public void SpeedUp(string name)
        {
            IFanDevice fan = this.GetFanDevice(name);

            if (fan.IsOn)
            {
                fan.FanSystem.SpeedUp();

                this.Unit.SaveChanges();
            }
        }

        public IFanDevice GetFanDevice(string name)
        {
            IFanDevice device;

            if ((device = this.Unit.GetRepository<Conditioner>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return device;
            }

            return default(IFanDevice);
        }
    }
}
