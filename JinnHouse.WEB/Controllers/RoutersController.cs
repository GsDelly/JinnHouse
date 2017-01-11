using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.BLL.Services.DeviceServices;
using JinnHouse.Entities.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers
{
    public class RoutersController : Controller
    {
        public IRouterService RouterService { get; set; }

        public RoutersController(IRouterService routerService)
        {
            this.RouterService = routerService;
        }

        public ActionResult Index()
        {
            IEnumerable<Router> routers = this.RouterService.GetAllRouters();
    
            return View(routers);
        }

        public ActionResult Switch(int id, string actionName, string controllerName)
        {
            this.RouterService.Switch(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult SwitchConnection(int id, string actionName, string controllerName)
        {
            this.RouterService.SwitchConnecton(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult AddDevice(string deviceName, string actionName, string controllerName)
        {
            this.RouterService.AddRouter(deviceName);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult RemoveDevice(int id, string actionName, string controllerName)
        {
            this.RouterService.RemoveRouter(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public bool IsExists(string deviceName)
        {
            return this.RouterService.IsExists(deviceName);
        }
    }
}