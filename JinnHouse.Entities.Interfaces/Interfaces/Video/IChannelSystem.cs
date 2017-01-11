using JinnHouse.Entities.Interfaces.Interfaces.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Video
{
    public interface IChannelSystem : IChannelControlable
    {
        string CurrentChannel { get; set; }

        int ChannelIndex { get; set; }

        IList<IChannel> Channels { get; set; }

        IList<IChannel> GetDefaultChannels();

        string GetChannelList();

    }
}
