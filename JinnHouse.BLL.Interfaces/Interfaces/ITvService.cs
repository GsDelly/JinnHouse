using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Entities.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Interfaces.Interfaces
{
    public interface ITvService
    {
        IUnitOfWork Unit { get; set; }

         TV GetTvById(int id);

         IEnumerable<TV> GetAllTvs();

         void Switch(int id);

         void RemoveTv(int id);

         void AddTv(string name);

         bool IsExists(string name);
    }
}
