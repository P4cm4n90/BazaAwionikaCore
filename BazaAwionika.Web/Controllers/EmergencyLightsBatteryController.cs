using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class EmergencyLightsBatteryController : Controller
    {
        private readonly IEmergencyLightsBatteryService emergencyLightsBatteryService;
        private readonly IAircraftService aircraftService;
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public EmergencyLightsBatteryController(IEmergencyLightsBatteryService emergencyLightsBatteryService, IAircraftService aircraftService, ISettingsService settingsService,
            IUserService userService)
        {
            this.emergencyLightsBatteryService = emergencyLightsBatteryService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: EmergencyLightsBattery
        public IActionResult Index()
        {
            IEnumerable<EmergencyLightsBatteryModel> emergencyLightsBatterys;
            IEnumerable<EmergencyLightsBatteryViewModel> emergencyLightsBatterysVM;
            emergencyLightsBatterys = emergencyLightsBatteryService.GetEmergencyLightsBatteries();
            emergencyLightsBatterysVM = AutoMapperConfiguration.Mapper.Map<IEnumerable<EmergencyLightsBatteryModel>, IEnumerable<EmergencyLightsBatteryViewModel>>(emergencyLightsBatterys);
            return View(emergencyLightsBatterysVM);

        }

        // GET: EmergencyLightsBattery/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            EmergencyLightsBatteryModel emergencyLightsBatteryModel = emergencyLightsBatteryService.GetEmergencyLightsBattery(id);
            if (emergencyLightsBatteryModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            EmergencyLightsBatteryViewModel emergencyLightsBatteryViewModel = AutoMapperConfiguration.Mapper.Map<EmergencyLightsBatteryModel, EmergencyLightsBatteryViewModel>(emergencyLightsBatteryModel);

            return PartialView(emergencyLightsBatteryViewModel);
        }

        // GET: EmergencyLightsBattery/Create
        public IActionResult Create()
        {
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View();
        }

        // POST: EmergencyLightsBattery/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( EmergencyLightsBatteryViewModel emergencyLightsBatteryViewModel)
        {
            if (ModelState.IsValid)
            {
                var emergencyLightsBatteryModel = AutoMapperConfiguration.Mapper.Map<EmergencyLightsBatteryModel>(emergencyLightsBatteryViewModel);
                emergencyLightsBatteryService.CreateEmergencyLightsBattery(emergencyLightsBatteryModel);
                emergencyLightsBatteryService.SaveEmergencyLightsBattery();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");

            return View(emergencyLightsBatteryViewModel);
        }

        // GET: EmergencyLightsBattery/Edit/5
        public IActionResult Edit(int id)
        {
            EmergencyLightsBatteryModel emergencyLightsBatteryModel = emergencyLightsBatteryService.GetEmergencyLightsBattery(id);
            EmergencyLightsBatteryViewModel emergencyLightsBatteryViewModel = AutoMapperConfiguration.Mapper.Map<EmergencyLightsBatteryViewModel>(emergencyLightsBatteryModel);
            if (emergencyLightsBatteryModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", emergencyLightsBatteryViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", emergencyLightsBatteryViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", emergencyLightsBatteryViewModel.UserId);

            return View(emergencyLightsBatteryViewModel);
        }

        // POST: EmergencyLightsBattery/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmergencyLightsBatteryViewModel emergencyLightsBatteryViewModel)
        {
            if (ModelState.IsValid)
            {
                EmergencyLightsBatteryModel emergencyLightsBatteryModel = emergencyLightsBatteryService.GetEmergencyLightsBattery(emergencyLightsBatteryViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<EmergencyLightsBatteryModel>(emergencyLightsBatteryViewModel);
                emergencyLightsBatteryService.SaveEmergencyLightsBattery();
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",emergencyLightsBatteryViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", emergencyLightsBatteryViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", emergencyLightsBatteryViewModel.UserId);
            return View(emergencyLightsBatteryViewModel);
        }

  

        // POST: EmergencyLightsBattery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            EmergencyLightsBatteryModel emergencyLightsBatteryModel = emergencyLightsBatteryService.GetEmergencyLightsBattery(id);

            emergencyLightsBatteryService.DeleteEmergencyLightsBattery(emergencyLightsBatteryModel);
            emergencyLightsBatteryService.SaveEmergencyLightsBattery();
            return RedirectToAction("Index");
        }


    }
}

