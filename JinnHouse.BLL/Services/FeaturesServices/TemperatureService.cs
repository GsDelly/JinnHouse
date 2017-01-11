using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Entities;
using JinnHouse.Entities.Entities.Fan;
using JinnHouse.Entities.Interfaces.Interfaces.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.FeaturesServices
{
    public class TemperatureService : ITemperatureService
    {
        public IUnitOfWork Unit { get; set; }

        public TemperatureService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public void TempDown(string name)
        {
            ITemperatureDevice tempDevice = this.GetTemperatureDevice(name);

            if (tempDevice != null)
            {
                tempDevice.DecreaseTemp();
                this.Unit.SaveChanges();
            }
        }

        public void TempUp(string name)
        {
            ITemperatureDevice tempDevice = this.GetTemperatureDevice(name);

            if (tempDevice != null)
            {
                tempDevice.IncreaseTemp();
                this.Unit.SaveChanges();
            }
        }

        public ITemperatureDevice GetTemperatureDevice(string name)
        {
            ITemperatureDevice device;

            if ((device = this.Unit.GetRepository<Conditioner>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
               return device;
            }
            if ((device = this.Unit.GetRepository<Oven>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return device;
            }

            return default(ITemperatureDevice);
        }
    }
}
