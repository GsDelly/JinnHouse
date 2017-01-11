using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces.Features
{
    public interface IFanService
    {
        IUnitOfWork Unit { get; set; }

        void SpeedDown(string name);

        void SpeedUp(string name);

        IFanDevice GetFanDevice(string name);
    }
}
