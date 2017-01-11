using JinnHouse.Entities.Entities.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces
{
    public interface IConditionerService
    {
        Conditioner GetConditionerById(int id);

        IEnumerable<Conditioner> GetAllConditioners();

        void Switch(int id);

        void RemoveConditioner(int id);

        void AddConditioner(string name);

        bool IsExists(string name);
    }
}
