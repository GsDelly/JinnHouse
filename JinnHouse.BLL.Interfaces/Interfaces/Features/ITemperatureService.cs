using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces.Features
{
    public interface ITemperatureService
    {
        IUnitOfWork Unit { get; set; }

        void TempDown(string device);

        void TempUp(string device);

        ITemperatureDevice GetTemperatureDevice(string device);
    }
}
