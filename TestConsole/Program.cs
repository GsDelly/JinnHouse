using JinnHouse.DAL.Interfaces;
using JinnHouse.DAL.Repositories;
using JinnHouse.Entities.Entities.Audio;
using JinnHouse.DAL.EFHouseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinnHouse.Entities.Entities;
using JinnHouse.Entities.Entities.Fan;
using JinnHouse.Entities.Entities.Video;
using JinnHouse.Entities.Entities.Web;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.Entities.Enums.Enums;

namespace TestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (IUnitOfWork unit = new EFUnitOfWork(new HouseContext("HouseContext")))
            {
                IEnumerable<AudioSystem> audios = unit.GetRepository<AudioSystem>().Get();
                IEnumerable<Oven> ovens = unit.GetRepository<Oven>().Get();
                IEnumerable<Conditioner> conders = unit.GetRepository<Conditioner>().Get();
                IEnumerable<Router> routers = unit.GetRepository<Router>().Get();
                IEnumerable<TV> videos = unit.GetRepository<TV>().Get();

                Router router = unit.GetRepository<Router>().Get().ElementAt(0);
                router.IsOn = false;
                unit.SaveChanges();
            }
            using (IUnitOfWork unit = new EFUnitOfWork(new HouseContext("HouseContext")))
            {
                IEnumerable<Router> routers = unit.GetRepository<Router>().Get();
                IEnumerable<TV> tvs = unit.GetRepository<TV>().Get();
            }
        }
    }
}
