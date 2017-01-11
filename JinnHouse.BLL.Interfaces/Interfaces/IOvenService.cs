using JinnHouse.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces
{
    public interface IOvenService
    {
        Oven GetOvenById(int id);

        IEnumerable<Oven> GetAllOvens();

        void Switch(int id);

        void RemoveOven(int id);

        void AddOven(string name);

        bool IsExists(string name);

        void SwitchModeForward(int id);

        void SwitchModeBackward(int id);
    }
}
