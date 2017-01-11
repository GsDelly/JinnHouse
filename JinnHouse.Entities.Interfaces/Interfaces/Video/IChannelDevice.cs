using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Video
{
    public interface IChannelDevice : IDevice
    {
        IChannelSystem ChannelSystem { get; set; }
    }
}
