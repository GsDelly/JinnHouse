namespace JinnHouse.DAL.EFHouseContext
{
    using Entities.Entities;
    using Entities.Entities.Audio;
    using Entities.Entities.Fan;
    using Entities.Entities.Video;
    using Entities.Entities.Web;
    using Entities.Enums.Enums;
    using Entities.Interfaces.Interfaces;
    using Entities.Interfaces.Interfaces.Audio;
    using Interfaces.Interfaces;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HouseDbInitializer : CreateDatabaseIfNotExists<HouseContext>
    {
        protected override void Seed(HouseContext context)
        {
            Router router1 = new Router()
            {
                Id = 3,
                Name = "EtherNet 1324_v",
            };

            TV tv1 = new TV(new ChannelSystem(1), new VolumeSystem(), new BrightSystem())
            {
                Id = 1,
                Name = "Berezka",           
            };

            TV tv2 = new TV(new ChannelSystem(2), new VolumeSystem(), new BrightSystem())
            {
                Id = 2,
                Name = "Samsung",
            };

            TV tv3 = new TV(new ChannelSystem(3), new VolumeSystem(), new BrightSystem())
            {
                Id = 3,
                Name = "Phillips",
            };

            Conditioner cond1 = new Conditioner(15, new FanSystem())
            {
                Id = 1,
                Name = "Fan 1",
            };

            Conditioner cond2 = new Conditioner(15, new FanSystem())
            {
                Id = 2,
                Name = "Fan 2",
            };

            Oven oven1 = new Oven(20, 100, 50)
            {
                Id = 1,
                Name = "Oven 1",
                OvenMode = OvenModes.Grill,
            };

            Oven oven2 = new Oven(25, 100, 40)
            {
                Id = 2,
                Name = "Oven 2",
                OvenMode = OvenModes.Microwave,
            };

            AudioSystem audio1 = new AudioSystem(new MusicalSystem(), new VolumeSystem())
            {
                Id = 1,
                Name = "Sony X54",
            };

            AudioSystem audio2 = new AudioSystem(new MusicalSystem(), new VolumeSystem())
            {
                Id = 2,
                Name = "AudioSystem 8.1",
            };

            context.TVs.Add(tv1);
            context.TVs.Add(tv2);
            context.TVs.Add(tv3);

            context.Ovens.Add(oven1);
            context.Ovens.Add(oven2);

            context.Routers.Add(router1);

            context.AudioSystems.Add(audio1);
            context.AudioSystems.Add(audio2);

            context.Conditioners.Add(cond1);
            context.Conditioners.Add(cond2);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
