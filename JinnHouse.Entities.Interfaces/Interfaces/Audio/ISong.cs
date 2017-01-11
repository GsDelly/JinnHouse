using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Audio
{
    public interface ISong
    {
        int Number { get; set; }
        string Name { get; set; }
        string Singer { get; set; }
    }
}
