using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.BLL.Services.DeviceServices;
using JinnHouse.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers
{
    public class OvensController : Controller
    {
        public IOvenService OvenService { get; set; }

        public OvensController(IOvenService OvenService)
        {
            this.OvenService = OvenService;
        }

        public ActionResult Index()
        {
            IEnumerable<Oven> Ovens = this.OvenService.GetAllOvens();

            return View(Ovens);
        }

        public ActionResult Switch(int id, string actionName, string controllerName)
        {
            this.OvenService.Switch(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult SwitchModeForward(int id, string actionName, string controllerName)
        {
            this.OvenService.SwitchModeForward(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult SwitchModeBackward(int id, string actionName, string controllerName)
        {
            this.OvenService.SwitchModeBackward(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult AddDevice(string deviceName, string actionName, string controllerName)
        {
            this.OvenService.AddOven(deviceName);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult RemoveDevice(int id, string actionName, string controllerName)
        {
            this.OvenService.RemoveOven(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public bool IsExists(string deviceName)
        {
            return this.OvenService.IsExists(deviceName);
        }
    }
}