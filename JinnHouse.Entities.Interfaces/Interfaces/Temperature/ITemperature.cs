using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Temperature
{
    public interface ITemperature
    {
        int Temperature { get; set; }
        int MinTemperature { get; }
        int MaxTemperature { get; }
    }
}
