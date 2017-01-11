using JinnHouse.BLL.Interfaces.Interfaces.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers.Features
{
    public class VolumeController : Controller
    {
        public IVolumeService VolumeService { get; set; }

        public VolumeController(IVolumeService volumeService)
        {
            this.VolumeService = volumeService;
        }

        public ActionResult VolumeUp(string id, string actionName, string controllerName)
        {
            this.VolumeService.VolumeUp(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult VolumeDown(string id, string actionName, string controllerName)
        {
            this.VolumeService.VolumeDown(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult Mute(string id, string actionName, string controllerName)
        {
            this.VolumeService.Mute(id);

            return RedirectToAction(actionName, controllerName);
        }
    }
}