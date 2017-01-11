using JinnHouse.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Web
{
    public interface IWebDevice : IDevice
    {
        bool IsConnected { get; set; }
    }
}
