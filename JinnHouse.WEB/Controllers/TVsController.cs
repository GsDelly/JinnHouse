using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.BLL.Services;
using JinnHouse.Entities.Entities.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers
{
    public class TVsController : Controller
    {
        public ITvService TvService { get; set; }

        public TVsController(ITvService tvService)
        {
            this.TvService = tvService;
        }

        public ActionResult Index()
        {
            IEnumerable<TV> TVs= this.TvService.GetAllTvs();

            return View(TVs);
        }

        public ActionResult Switch(int id, string actionName, string controllerName)
        {
            this.TvService.Switch(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult AddDevice(string deviceName, string actionName, string controllerName)
        {
            this.TvService.AddTv(deviceName);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult RemoveDevice(int id, string actionName, string controllerName)
        {
            this.TvService.RemoveTv(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public bool IsExists(string deviceName)
        {
            return this.TvService.IsExists(deviceName);
        }
    }
}