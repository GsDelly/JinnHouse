using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces
{
    public interface IVolumeDevice : IDevice
    {
        IVolumeSystem VolumeSystem { get; set; }
    }
}
