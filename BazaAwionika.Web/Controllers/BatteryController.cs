using System.Collections.Generic;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class BatteryController : Controller
    {
        private readonly IBatteryService batteryService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public BatteryController(IBatteryService batteryService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.batteryService = batteryService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: Battery
        public IActionResult Index()
        {
            IEnumerable<BatteryModel> batteryModels;
            IEnumerable<BatteryViewModel> batteryViewModels;
            batteryModels = batteryService.GetBatteries();
            batteryViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<BatteryModel>,IEnumerable<BatteryViewModel>>(batteryModels);

            return View(batteryViewModels);
        }

        // GET: Battery/Details/5
        public IActionResult Details(int id)
        {
            BatteryModel batteryModel = batteryService.GetBattery(id);
            if (batteryModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            BatteryViewModel batteryViewModel = AutoMapperConfiguration.Mapper.Map<BatteryViewModel>(batteryModel);
            return PartialView(batteryViewModel);
        }

        // GET: Battery/Create
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

        // POST: Battery/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BatteryViewModel batteryViewModel)
        {
            if (ModelState.IsValid)
            {
                BatteryModel batteryModel = AutoMapperConfiguration.Mapper.Map<BatteryModel>(batteryViewModel);
                batteryService.CreateBattery(batteryModel);
                batteryService.SaveBattery();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(batteryViewModel);
        }

        // GET: Battery/Edit/5
        public IActionResult Edit(int id)
        {
            BatteryModel batteryModel = batteryService.GetBattery(id);
            BatteryViewModel batteryViewModel = AutoMapperConfiguration.Mapper.Map<BatteryViewModel>(batteryModel);
            if (batteryModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",batteryViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", batteryViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",batteryViewModel.UserId);
            return View(batteryViewModel);
        }

        // POST: Battery/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BatteryViewModel batteryViewModel)
        {
            if (ModelState.IsValid)
            {
                BatteryModel batteryModel = batteryService.GetBattery(batteryViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(batteryViewModel,batteryModel);
                batteryService.SaveBattery();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", batteryViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", batteryViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", batteryViewModel.UserId);
            return View(batteryViewModel);
        }


        // POST: Battery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            BatteryModel batteryModel = batteryService.GetBattery(id);
            batteryService.DeleteBattery(batteryModel);
            batteryService.SaveBattery();
            return RedirectToAction("Index");
        }


    }
}
