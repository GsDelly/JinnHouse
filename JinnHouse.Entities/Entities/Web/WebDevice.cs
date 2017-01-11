using JinnHouse.Entities.Entities;
using JinnHouse.Entities.Interfaces.Interfaces.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinnHouse.Entities.Entities.Web
{
    public abstract class WebDevice : Device, IWebDevice, IConnectable
    {

        public WebDevice()
        {
            this.IsConnected = true;
        }

        public bool IsConnected { get; set; }

        public void Connect()
        {
            this.IsConnected = true;
        }

        public void Disconnect()
        {
            this.IsConnected = false;
        }
    }
}
