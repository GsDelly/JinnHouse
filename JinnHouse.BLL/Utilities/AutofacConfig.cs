using Autofac;
using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.BLL.Services;
using JinnHouse.BLL.Services.DeviceServices;
using JinnHouse.BLL.Services.FeaturesServices;
using JinnHouse.DAL.EFHouseContext;
using JinnHouse.DAL.Interfaces.Interfaces;
using JinnHouse.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.BLL.Utilities
{
    public class AutofacConfig
    {
        public static void Configure(ref ContainerBuilder builder)
        {
            // Data access config
            builder.Register(db => new HouseContext("HouseContext")).InstancePerRequest();
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();
            // Services config
            builder.RegisterType<RouterService>().As<IRouterService>();
            builder.RegisterType<TvService>().As<ITvService>();
            builder.RegisterType<OvenService>().As<IOvenService>();
            builder.RegisterType<AudioSystemService>().As<IAudioSystemService>();
            builder.RegisterType<ConditionerService>().As<IConditionerService>();
            builder.RegisterType<TemperatureService>().As<ITemperatureService>();
            builder.RegisterType<FanService>().As<IFanService>();
            builder.RegisterType<BrightService>().As<IBrightService>();
            builder.RegisterType<VolumeService>().As<IVolumeService>();
            builder.RegisterType<ChannelService>().As<IChannelService>();
            builder.RegisterType<SongService>().As<ISongService>();
        }
    }
}

