using JinnHouse.BLL.Interfaces.Interfaces.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers.Features
{
    public class ChannelController : Controller
    {
        public IChannelService ChannelService { get; set; }

        public ChannelController(IChannelService channelService)
        {
            this.ChannelService = channelService;
        }

        public ActionResult NextChannel(string id, string actionName, string controllerName)
        {
            this.ChannelService.NextChannel(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult PreviousChannel(string id, string actionName, string controllerName)
        {
            this.ChannelService.PreviousChannel(id);

            return RedirectToAction(actionName, controllerName);
        }
    }
}