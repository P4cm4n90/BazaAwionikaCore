using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class GpsBatteriesController : Controller
    {
        private readonly IGpsBatteriesService gpsBatteriesService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public GpsBatteriesController(IGpsBatteriesService gpsBatteriesService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.gpsBatteriesService = gpsBatteriesService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: GpsBatteries
        public IActionResult Index()
        {
            IEnumerable<GpsBatteriesModel> gpsBatteriesModels;
            IEnumerable<GpsBatteriesViewModel> gpsBatteriesViewModels;
            gpsBatteriesModels = gpsBatteriesService.GetGpsBatteries();
            gpsBatteriesViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<GpsBatteriesModel>,IEnumerable<GpsBatteriesViewModel>>(gpsBatteriesModels);

            return View(gpsBatteriesViewModels);
        }

        // GET: GpsBatteries/Details/5
        public IActionResult Details(int id)
        {
            GpsBatteriesModel gpsBatteriesModel = gpsBatteriesService.GetGpsBatteries(id);
            if (gpsBatteriesModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(gpsBatteriesModel);
        }

        // GET: GpsBatteries/Create
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

        // POST: GpsBatteries/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GpsBatteriesViewModel gpsBatteriesViewModel)
        {
            if (ModelState.IsValid)
            {
                GpsBatteriesModel gpsBatteriesModel = AutoMapperConfiguration.Mapper.Map<GpsBatteriesModel>(gpsBatteriesViewModel);
                gpsBatteriesService.CreateGpsBatteries(gpsBatteriesModel);
                gpsBatteriesService.SaveGpsBatteries();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(gpsBatteriesViewModel);
        }

        // GET: GpsBatteries/Edit/5
        public IActionResult Edit(int id)
        {
            GpsBatteriesModel gpsBatteriesModel = gpsBatteriesService.GetGpsBatteries(id);
            GpsBatteriesViewModel gpsBatteriesViewModel = AutoMapperConfiguration.Mapper.Map<GpsBatteriesViewModel>(gpsBatteriesModel);
            if (gpsBatteriesModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",gpsBatteriesViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", gpsBatteriesViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",gpsBatteriesViewModel.UserId);
            return View(gpsBatteriesViewModel);
        }

        // POST: GpsBatteries/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GpsBatteriesViewModel gpsBatteriesViewModel)
        {
            if (ModelState.IsValid)
            {
                GpsBatteriesModel gpsBatteriesModel = gpsBatteriesService.GetGpsBatteries(gpsBatteriesViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(gpsBatteriesViewModel, gpsBatteriesModel);
                gpsBatteriesService.SaveGpsBatteries();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", gpsBatteriesViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", gpsBatteriesViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", gpsBatteriesViewModel.UserId);
            return View(gpsBatteriesViewModel);
        }



        // POST: GpsBatteries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            GpsBatteriesModel gpsBatteriesModel = gpsBatteriesService.GetGpsBatteries(id);
            gpsBatteriesService.DeleteGpsBatteries(gpsBatteriesModel);
            gpsBatteriesService.SaveGpsBatteries();
            return RedirectToAction("Index");
        }


    }
}
