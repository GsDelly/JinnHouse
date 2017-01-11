using JinnHouse.BLL.Interfaces.Interfaces.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers.Features
{
    public class FanController : Controller
    {
        public IFanService FanService { get; set; }

        public FanController(IFanService fanService)
        {
            this.FanService = fanService;
        }
        // GET: Fan
        public ActionResult SpeedDown(string id, string actionName, string controllerName)
        {
            this.FanService.SpeedDown(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult SpeedUp(string id, string actionName, string controllerName)
        {
            this.FanService.SpeedUp(id);

            return RedirectToAction(actionName, controllerName);
        }
    }
}