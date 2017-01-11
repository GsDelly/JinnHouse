using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces.Features
{
    public interface IVolumeService
    {
        IUnitOfWork Unit { get; set; }

        void VolumeDown(string name);

        void VolumeUp(string name);

        void Mute(string name);

        IVolumeDevice GetVolumeDevice(string name);
    }
}
