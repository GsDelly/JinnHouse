using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Entities.Video;
using JinnHouse.Entities.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Services.FeaturesServices
{
    public class ChannelService : IChannelService
    {
        public IUnitOfWork Unit { get; set; }

        public ChannelService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public void PreviousChannel(string name)
        {
            IChannelDevice channel = this.GetChannelDevice(name);

            if (channel.IsOn)
            {
                channel.ChannelSystem.SwitchBackward();

                this.Unit.SaveChanges();
            }
        }

        public void NextChannel(string name)
        {
            IChannelDevice channel = this.GetChannelDevice(name);

            if (channel.IsOn)
            {
                channel.ChannelSystem.SwitchForward();

                this.Unit.SaveChanges();
            }
        }

        public IChannelDevice GetChannelDevice(string name)
        {
            IChannelDevice channel;

            if ((channel = this.Unit.GetRepository<TV>().Get(filter: x => x.Name == name).FirstOrDefault()) != null)
            {
                return channel;
            }

            return default(IChannelDevice);
        }
    }
}
