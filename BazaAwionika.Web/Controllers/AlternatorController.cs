using System.Collections.Generic;
using System.Net;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class AlternatorController : Controller
    {
        private readonly IAlternatorService alternatorService;
        private readonly IAircraftService aircraftService;
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public AlternatorController(IAlternatorService alternatorService, IAircraftService aircraftService, ISettingsService settingsService,
            IUserService userService)
        {
            this.alternatorService = alternatorService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: Alternator
        public IActionResult Index()
        {
            IEnumerable<AlternatorModel> alternators;
            IEnumerable<AlternatorViewModel> alternatorsVM;
            alternators = alternatorService.GetAlternators();
            alternatorsVM = AutoMapperConfiguration.Mapper.Map<IEnumerable<AlternatorModel>, IEnumerable<AlternatorViewModel>> (alternators);
            return View(alternatorsVM);

        }

        // GET: Alternator/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            AlternatorModel alternatorModel = alternatorService.GetAlternator(id);
            if (alternatorModel == null)
                
                new StatusCodeResult(StatusCodes.Status404NotFound);
            AlternatorViewModel alternatorViewModel = AutoMapperConfiguration.Mapper.Map<AlternatorModel, AlternatorViewModel>(alternatorModel);
            //TODO: zastanowic sie czyd ac tu model czy viewmodel
            return PartialView(alternatorViewModel);
        }

        // GET: Alternator/Create
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

        // POST: Alternator/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AlternatorViewModel alternatorViewModel)
        {
            if (ModelState.IsValid)
            {
                AlternatorModel alternatorModel = AutoMapperConfiguration.Mapper.Map<AlternatorModel>(alternatorViewModel);

                alternatorService.CreateAlternator(alternatorModel);
                alternatorService.SaveAlternator();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");

            return View(alternatorViewModel);
        }

        // GET: Alternator/Edit/5
        public IActionResult Edit(int id)
        {
            AlternatorModel alternatorModel = alternatorService.GetAlternator(id);
            AlternatorViewModel alternatorViewModel = AutoMapperConfiguration.Mapper.Map<AlternatorViewModel>(alternatorModel);
            if (alternatorModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",alternatorViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", alternatorViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",alternatorViewModel.UserId);

            return View(alternatorViewModel);
        }

        // POST: Alternator/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AlternatorViewModel alternatorViewModel)
        {
            if (ModelState.IsValid)
            {
                AlternatorModel alternatorModel = alternatorService.GetAlternator(alternatorViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<AlternatorModel>(alternatorViewModel);
                alternatorService.SaveAlternator();
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", alternatorViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", alternatorViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", alternatorViewModel.UserId);
            return View(alternatorViewModel);
        }

        // GET: Alternator/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            AlternatorModel alternatorModel = alternatorService.GetAlternator(id);

            alternatorService.DeleteAlternator(alternatorModel);
            alternatorService.SaveAlternator();
            return RedirectToAction("Index");
        }


    }
}

