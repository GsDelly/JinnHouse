using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces
{
    public interface IDevice : ISwitchable
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsOn { get; set; }
    }
}
