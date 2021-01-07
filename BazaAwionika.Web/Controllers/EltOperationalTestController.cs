using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class EltOperationalTestController : Controller
    {
        private readonly IEltOperationalTestService eltOperationalTestService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public EltOperationalTestController(IEltOperationalTestService eltOperationalTestService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.eltOperationalTestService = eltOperationalTestService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: EltOperationalTest
        public IActionResult Index()
        {
            IEnumerable<EltOperationalTestModel> eltOperationalTestModels;
            IEnumerable<EltOperationalTestViewModel> eltOperationalTestViewModels;
            eltOperationalTestModels = eltOperationalTestService.GetEltOperationalTests();
            eltOperationalTestViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<EltOperationalTestModel>, IEnumerable<EltOperationalTestViewModel>>(eltOperationalTestModels);

            return View(eltOperationalTestViewModels);
        }

        // GET: EltOperationalTest/Details/5
        public IActionResult Details(int id)
        {
            EltOperationalTestModel eltOperationalTestModel = eltOperationalTestService.GetEltOperationalTest(id);
            if (eltOperationalTestModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            return PartialView(eltOperationalTestModel);
        }

        // GET: EltOperationalTest/Create
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

        // POST: EltOperationalTest/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EltOperationalTestViewModel eltOperationalTestViewModel)
        {
            if (ModelState.IsValid)
            {
                var eltOperationalTestModel = AutoMapperConfiguration.Mapper.Map<EltOperationalTestModel>(eltOperationalTestViewModel);
                eltOperationalTestService.CreateEltOperationalTest(eltOperationalTestModel);
                eltOperationalTestService.SaveEltOperationalTest();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(eltOperationalTestViewModel);
        }

        // GET: EltOperationalTest/Edit/5
        public IActionResult Edit(int id)
        {
            EltOperationalTestModel eltOperationalTestModel = eltOperationalTestService.GetEltOperationalTest(id);
            EltOperationalTestViewModel eltOperationalTestViewModel = AutoMapperConfiguration.Mapper.Map<EltOperationalTestViewModel>(eltOperationalTestModel);
            if (eltOperationalTestModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", eltOperationalTestViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", eltOperationalTestViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", eltOperationalTestViewModel.UserId);
            return View(eltOperationalTestViewModel);
        }

        // POST: EltOperationalTest/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EltOperationalTestViewModel eltOperationalTestViewModel)
        {
            if (ModelState.IsValid)
            {
                EltOperationalTestModel eltOperationalTestModel = eltOperationalTestService.GetEltOperationalTest(eltOperationalTestViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(eltOperationalTestViewModel, eltOperationalTestModel);
                eltOperationalTestService.SaveEltOperationalTest();

                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", eltOperationalTestViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", eltOperationalTestViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", eltOperationalTestViewModel.UserId);
            return View(eltOperationalTestViewModel);
        }

 

        // POST: EltOperationalTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            EltOperationalTestModel eltOperationalTestModel = eltOperationalTestService.GetEltOperationalTest(id);
            eltOperationalTestService.DeleteEltOperationalTest(eltOperationalTestModel);
            eltOperationalTestService.SaveEltOperationalTest();
            return RedirectToAction("Index");
        }


    }
}

               