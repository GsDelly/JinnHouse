using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Audio
{
    public interface IMusicDevice : IDevice
    {
        IMusicSystem MusicSystem { get; set; }
    }
}
