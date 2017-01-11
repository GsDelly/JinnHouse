using JinnHouse.BLL.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnSports.BLL.Dto
{
    public class RouterDto : DeviceDto, IRouterDto
    {
        public bool IsConnected { get; set; }
    }
}
