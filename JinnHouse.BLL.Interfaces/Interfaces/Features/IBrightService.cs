using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces.Features
{
    public interface IBrightService
    {
        IUnitOfWork Unit { get; set; }

        void BrightDown(string name);

        void BrightUp(string name);

        IBrightDevice GetBrightDevice(string name);
    }
}
