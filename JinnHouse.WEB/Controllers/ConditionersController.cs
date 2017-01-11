using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.BLL.Services.DeviceServices;
using JinnHouse.Entities.Entities.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers
{
    public class ConditionersController : Controller
    {
        public IConditionerService ConditionerService { get; set; }

        public ConditionersController(IConditionerService ConditionerService)
        {
            this.ConditionerService = ConditionerService;
        }

        public ActionResult Index()
        {
            IEnumerable<Conditioner> Conditioners = this.ConditionerService.GetAllConditioners();

            return View(Conditioners);
        }

        public ActionResult Switch(int id, string actionName, string controllerName)
        {
            this.ConditionerService.Switch(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult AddDevice(string deviceName, string actionName, string controllerName)
        {
            this.ConditionerService.AddConditioner(deviceName);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult RemoveDevice(int id, string actionName, string controllerName)
        {
            this.ConditionerService.RemoveConditioner(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public bool IsExists(string deviceName)
        {
            return this.ConditionerService.IsExists(deviceName);
        }
    }
}