using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Interfaces.Interfaces.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces.Features
{
    public interface ISongService
    {
        IUnitOfWork Unit { get; set; }

        void NextSong(string name);

        void PreviousSong(string name);

        IMusicDevice GetMusicalDevice(string name);
    }
}
