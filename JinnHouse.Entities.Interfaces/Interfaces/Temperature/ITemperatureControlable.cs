﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Interfaces.Interfaces.Temperature
{
    public interface ITemperatureControlable
    {
        void IncreaseTemp();
        void DecreaseTemp();
    }
}