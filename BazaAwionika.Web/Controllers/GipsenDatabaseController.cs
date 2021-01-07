using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class GipsenDatabaseController : Controller
    {
        private readonly IGipsenDatabaseService gipsenDatabaseService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public GipsenDatabaseController(IGipsenDatabaseService gipsenDatabaseService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.gipsenDatabaseService = gipsenDatabaseService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: GipsenDatabase
        public IActionResult Index()
        {
            IEnumerable<GipsenDatabaseModel> gipsenDatabaseModels;
            IEnumerable<GipsenDatabaseViewModel> gipsenDatabaseViewModels;
            gipsenDatabaseModels = gipsenDatabaseService.GetGipsenDatabases();
            gipsenDatabaseViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<GipsenDatabaseModel>,IEnumerable<GipsenDatabaseViewModel>>(gipsenDatabaseModels);

            return View(gipsenDatabaseViewModels);
        }

        // GET: GipsenDatabase/Details/5
        public IActionResult Details(int id)
        {
            GipsenDatabaseModel gipsenDatabaseModel = gipsenDatabaseService.GetGipsenDatabase(id);
            if (gipsenDatabaseModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(gipsenDatabaseModel);
        }

        // GET: GipsenDatabase/Create
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

        // POST: GipsenDatabase/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GipsenDatabaseViewModel gipsenDatabaseViewModel)
        {
            if (ModelState.IsValid)
            { 
                var gipsenDatabaseModel = AutoMapperConfiguration.Mapper.Map<GipsenDatabaseModel>(gipsenDatabaseViewModel);
                gipsenDatabaseService.CreateGipsenDatabase(gipsenDatabaseModel);
                gipsenDatabaseService.SaveGipsenDatabase();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(gipsenDatabaseViewModel);
        }

        // GET: GipsenDatabase/Edit/5
        public IActionResult Edit(int id)
        {
            GipsenDatabaseModel gipsenDatabaseModel = gipsenDatabaseService.GetGipsenDatabase(id);
            GipsenDatabaseViewModel gipsenDatabaseViewModel = AutoMapperConfiguration.Mapper.Map<GipsenDatabaseViewModel>(gipsenDatabaseModel);
            if (gipsenDatabaseModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",gipsenDatabaseViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", gipsenDatabaseViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",gipsenDatabaseViewModel.UserId);
            return View(gipsenDatabaseViewModel);
        }

        // POST: GipsenDatabase/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GipsenDatabaseViewModel gipsenDatabaseViewModel)
        {
            if (ModelState.IsValid)
            {
                GipsenDatabaseModel gipsenDatabaseModel = gipsenDatabaseService.GetGipsenDatabase(gipsenDatabaseViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(gipsenDatabaseViewModel, gipsenDatabaseModel);
                gipsenDatabaseService.SaveGipsenDatabase();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", gipsenDatabaseViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", gipsenDatabaseViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", gipsenDatabaseViewModel.UserId);
            return View(gipsenDatabaseViewModel);
        }



        // POST: GipsenDatabase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            GipsenDatabaseModel gipsenDatabaseModel = gipsenDatabaseService.GetGipsenDatabase(id);
            gipsenDatabaseService.DeleteGipsenDatabase(gipsenDatabaseModel);
            gipsenDatabaseService.SaveGipsenDatabase();
            return RedirectToAction("Index");
        }


    }
}
