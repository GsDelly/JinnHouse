using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces
{
    public interface IBrightDevice : IDevice
    {
        IBrightSystem BrightSystem { get; set; }
    }
}
