using JinnHouse.BLL.Interfaces.Interfaces;
using JinnHouse.BLL.Services.DeviceServices;
using JinnHouse.Entities.Entities.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinnHouse.WEB.Controllers
{
    public class AudioSystemsController : Controller
    {
        public IAudioSystemService AudioSystemService { get; set; }

        public AudioSystemsController(IAudioSystemService AudioSystemService)
        {
            this.AudioSystemService = AudioSystemService;
        }

        public ActionResult Index()
        {
            IEnumerable<AudioSystem> AudioSystems = this.AudioSystemService.GetAllAudioSystems();

            return View(AudioSystems);
        }

        public ActionResult Switch(int id, string actionName, string controllerName)
        {
            this.AudioSystemService.Switch(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult AddDevice(string deviceName, string actionName, string controllerName)
        {
            this.AudioSystemService.AddAudioSystem(deviceName);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public ActionResult RemoveDevice(int id, string actionName, string controllerName)
        {
            this.AudioSystemService.RemoveAudioSystem(id);

            return RedirectToAction(actionName, controllerName);
        }

        [HttpPost]
        public bool IsExists(string deviceName)
        {
            return this.AudioSystemService.IsExists(deviceName);
        }
    }
}