using JinnHouse.Entities.Enums.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Fan
{
    public interface IFanSystem : IFanControlable
    {
        FanSpeed FanSpeed { get; set; }
    }
}
