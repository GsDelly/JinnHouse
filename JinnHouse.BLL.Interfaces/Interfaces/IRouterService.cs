using JinnHouse.Entities.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces
{
    public interface IRouterService
    {
        Router GetRouterById(int id);

        IEnumerable<Router> GetAllRouters();

        void Switch(int id);

        void SwitchConnecton(int id);

        void RemoveRouter(int id);

        void AddRouter(string name);

        bool IsExists(string name);
    }
}
