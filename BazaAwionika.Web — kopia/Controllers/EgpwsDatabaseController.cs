using System.Collections.Generic;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class EgpwsDatabaseController : Controller
    {
        private readonly IEgpwsDatabaseService egpwsDatabaseService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public EgpwsDatabaseController(IEgpwsDatabaseService egpwsDatabaseService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.egpwsDatabaseService = egpwsDatabaseService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: EgpwsDatabase
        public IActionResult Index()
        {
            IEnumerable<EgpwsDatabaseModel> egpwsDatabaseModels;
            IEnumerable<EgpwsDatabaseViewModel> egpwsDatabaseViewModels;
            egpwsDatabaseModels = egpwsDatabaseService.GetEgpwsDatabases();
            egpwsDatabaseViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<EgpwsDatabaseModel>,IEnumerable<EgpwsDatabaseViewModel>>(egpwsDatabaseModels);

            return View(egpwsDatabaseViewModels);
        }

        // GET: EgpwsDatabase/Details/5
        public IActionResult Details(int id)
        {
            EgpwsDatabaseModel egpwsDatabaseModel = egpwsDatabaseService.GetEgpwsDatabase(id);
            if (egpwsDatabaseModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(egpwsDatabaseModel);
        }

        // GET: EgpwsDatabase/Create
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

        // POST: EgpwsDatabase/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EgpwsDatabaseViewModel egpwsDatabaseViewModel)
        {
            if (ModelState.IsValid)
            {
                EgpwsDatabaseModel egpwsDatabaseModel = AutoMapperConfiguration.Mapper.Map<EgpwsDatabaseModel>(egpwsDatabaseViewModel);
                egpwsDatabaseService.CreateEgpwsDatabase(egpwsDatabaseModel);
                egpwsDatabaseService.SaveEgpwsDatabase();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(egpwsDatabaseViewModel);
        }

        // GET: EgpwsDatabase/Edit/5
        public IActionResult Edit(int id)
        {
            EgpwsDatabaseModel egpwsDatabaseModel = egpwsDatabaseService.GetEgpwsDatabase(id);
            EgpwsDatabaseViewModel egpwsDatabaseViewModel = AutoMapperConfiguration.Mapper.Map<EgpwsDatabaseViewModel>(egpwsDatabaseModel);
            if (egpwsDatabaseModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",egpwsDatabaseViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", egpwsDatabaseViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",egpwsDatabaseViewModel.UserId);
            return View(egpwsDatabaseViewModel);
        }

        // POST: EgpwsDatabase/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EgpwsDatabaseViewModel egpwsDatabaseViewModel)
        {
            if (ModelState.IsValid)
            {
                EgpwsDatabaseModel egpwsDatabaseModel = egpwsDatabaseService.GetEgpwsDatabase(egpwsDatabaseViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<EgpwsDatabaseModel>(egpwsDatabaseViewModel);
                egpwsDatabaseService.SaveEgpwsDatabase();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", egpwsDatabaseViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", egpwsDatabaseViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", egpwsDatabaseViewModel.UserId);
            return View(egpwsDatabaseViewModel);
        }

        // GET: EgpwsDatabase/Delete/

        // POST: EgpwsDatabase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            EgpwsDatabaseModel egpwsDatabaseModel = egpwsDatabaseService.GetEgpwsDatabase(id);
            egpwsDatabaseService.DeleteEgpwsDatabase(egpwsDatabaseModel);
            egpwsDatabaseService.SaveEgpwsDatabase();
            return RedirectToAction("Index");
        }


    }
}
