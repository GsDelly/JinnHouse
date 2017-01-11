using JinnHouse.BLL.Interfaces.Interfaces.Features;
using JinnHouse.Entities.Interfaces.Interfaces.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers.Features
{
    public class SongController : Controller
    {
        public ISongService SongService { get; set; }

        public SongController(ISongService SongService)
        {
            this.SongService = SongService;
        }

        public ActionResult NextSong(string id, string actionName, string controllerName)
        {
            this.SongService.NextSong(id);

            return RedirectToAction(actionName, controllerName);
        }

        public ActionResult PreviousSong(string id, string actionName, string controllerName)
        {
            this.SongService.PreviousSong(id);

            return RedirectToAction(actionName, controllerName);
        }
    }
}