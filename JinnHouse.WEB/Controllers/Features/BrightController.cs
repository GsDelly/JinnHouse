using JinnHouse.BLL.Interfaces.Interfaces.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers.Features
{
    public class BrightController : Controller
    {
        public IBrightService BrightService { get; set; }

        public BrightController(IBrightService brightService)
        {
            this.BrightService = brightService;
        }
        
        public ActionResult BrightUp(string id, string actionName, string controllerName)
        {
            this.BrightService.BrightUp(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult BrightDown(string id, string actionName, string controllerName)
        {
            this.BrightService.BrightDown(id);

            return RedirectToAction(actionName, controllerName);
        }
    }
}