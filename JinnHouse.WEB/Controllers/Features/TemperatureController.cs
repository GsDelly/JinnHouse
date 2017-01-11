using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.Entities.Interfaces.Interfaces.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers.Features
{
    public class TemperatureController : Controller
    {
        public ITemperatureService TemperatureService { get; set; }

        public TemperatureController(ITemperatureService temperatureService)
        {
            this.TemperatureService = temperatureService;
        }

        public ActionResult TempDown(string id, string actionName, string controllerName)
        {
            this.TemperatureService.TempDown(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult TempUp(string id, string actionName, string controllerName)
        {
            this.TemperatureService.TempUp(id);

            return RedirectToAction(actionName, controllerName);
        }
    }
}