using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class GpsPCodesController : Controller
    {
        private readonly IGpsPCodesService gpsPCodesService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public GpsPCodesController(IGpsPCodesService gpsPCodesService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.gpsPCodesService = gpsPCodesService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: GpsPCodes
        public IActionResult Index()
        {
            IEnumerable<GpsPCodesModel> gpsPCodesModels;
            IEnumerable<GpsPCodesViewModel> gpsPCodesViewModels;
            gpsPCodesModels = gpsPCodesService.GetGpsPCodes();
            gpsPCodesViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<GpsPCodesModel>,IEnumerable<GpsPCodesViewModel>>(gpsPCodesModels);

            return View(gpsPCodesViewModels);
        }

        // GET: GpsPCodes/Details/5
        public IActionResult Details(int id)
        {
            GpsPCodesModel gpsPCodesModel = gpsPCodesService.GetGpsPCodes(id);
            if (gpsPCodesModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(gpsPCodesModel);
        }

        // GET: GpsPCodes/Create
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

        // POST: GpsPCodes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GpsPCodesViewModel gpsPCodesViewModel)
        {
            if (ModelState.IsValid)
            {
                GpsPCodesModel gpsPCodesModel = AutoMapperConfiguration.Mapper.Map<GpsPCodesModel>(gpsPCodesViewModel);
                gpsPCodesService.CreateGpsPCodes(gpsPCodesModel);
                gpsPCodesService.SaveGpsPCodes();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(gpsPCodesViewModel);
        }

        // GET: GpsPCodes/Edit/5
        public IActionResult Edit(int id)
        {
            GpsPCodesModel gpsPCodesModel = gpsPCodesService.GetGpsPCodes(id);
            GpsPCodesViewModel gpsPCodesViewModel = AutoMapperConfiguration.Mapper.Map<GpsPCodesViewModel>(gpsPCodesModel);
            if (gpsPCodesModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",gpsPCodesViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", gpsPCodesViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",gpsPCodesViewModel.UserId);
            return View(gpsPCodesViewModel);
        }

        // POST: GpsPCodes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GpsPCodesViewModel gpsPCodesViewModel)
        {
            if (ModelState.IsValid)
            {
                GpsPCodesModel gpsPCodesModel = gpsPCodesService.GetGpsPCodes(gpsPCodesViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<GpsPCodesModel>(gpsPCodesViewModel);
                gpsPCodesService.SaveGpsPCodes();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", gpsPCodesViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", gpsPCodesViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", gpsPCodesViewModel.UserId);
            return View(gpsPCodesViewModel);
        }

 

        // POST: GpsPCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            GpsPCodesModel gpsPCodesModel = gpsPCodesService.GetGpsPCodes(id);
            gpsPCodesService.DeleteGpsPCodes(gpsPCodesModel);
            gpsPCodesService.SaveGpsPCodes();
            return RedirectToAction("Index");
        }


    }
}
