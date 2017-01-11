using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces.Features
{
    public interface IChannelService
    {
        IUnitOfWork Unit { get; set; }

        void NextChannel(string name);

        void PreviousChannel(string name);

        IChannelDevice GetChannelDevice(string name);
    }
}
