using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces
{
    public interface IVolume
    {
        int Volume { get; set; }
        int MaxVolume { get; set; }
        int MinVolume { get; set; }
    }
}
