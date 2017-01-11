using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.BLL.Services.FeaturesServices;
using JinnHouse.DAL.EFHouseContext;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.DAL.Repositories;
using JinnHouse.Entities.Entities.Video;
using JinnHouse.Entities.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.FeaturesServices
{
    public class BrightService : IBrightService
    {
        public IUnitOfWork Unit { get; set; }

        public BrightService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public void BrightDown(string name)
        {
            IBrightDevice bright = this.GetBrightDevice(name);

            if (bright.IsOn)
            {
                bright.BrightSystem.BrightDown();

                this.Unit.SaveChanges();
            }
        }

        public void BrightUp(string name)
        {
            IBrightDevice bright = this.GetBrightDevice(name);

            if (bright.IsOn)
            {
                bright.BrightSystem.BrightUp();

                this.Unit.SaveChanges();
            }
        }

        public IBrightDevice GetBrightDevice(string name)
        {
            IBrightDevice bright;

            if ((bright = this.Unit.GetRepository<TV>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return bright;
            }

            return default(IBrightDevice);
        }
    }
}
