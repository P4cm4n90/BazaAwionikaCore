using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class EltFunctionalTestController : Controller
    {
        private readonly IEltFunctionalTestService eltFunctionalTestService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public EltFunctionalTestController(IEltFunctionalTestService eltFunctionalTestService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.eltFunctionalTestService = eltFunctionalTestService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: EltFunctionalTest
        public IActionResult Index()
        {
            IEnumerable<EltFunctionalTestModel> eltFunctionalTestModels;
            IEnumerable<EltFunctionalTestViewModel> eltFunctionalTestViewModels;
            eltFunctionalTestModels = eltFunctionalTestService.GetEltFunctionalTests();
            eltFunctionalTestViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<EltFunctionalTestModel>,IEnumerable<EltFunctionalTestViewModel>>(eltFunctionalTestModels);

            return View(eltFunctionalTestViewModels);
        }

        // GET: EltFunctionalTest/Details/5
        public IActionResult Details(int id)
        {
            EltFunctionalTestModel eltFunctionalTestModel = eltFunctionalTestService.GetEltFunctionalTest(id);
            if (eltFunctionalTestModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(eltFunctionalTestModel);
        }

        // GET: EltFunctionalTest/Create
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

        // POST: EltFunctionalTest/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EltFunctionalTestViewModel eltFunctionalViewTestModel)
        {
            if (ModelState.IsValid)
            {
                var eltFunctionalTestModel = AutoMapperConfiguration.Mapper.Map<EltFunctionalTestModel>(eltFunctionalViewTestModel);
                eltFunctionalTestService.CreateEltFunctionalTest(eltFunctionalTestModel);
                eltFunctionalTestService.SaveEltFunctionalTest();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(eltFunctionalViewTestModel);
        }

        // GET: EltFunctionalTest/Edit/5
        public IActionResult Edit(int id)
        {
            EltFunctionalTestModel eltFunctionalTestModel = eltFunctionalTestService.GetEltFunctionalTest(id);
            EltFunctionalTestViewModel eltFunctionalTestViewModel = AutoMapperConfiguration.Mapper.Map<EltFunctionalTestViewModel>(eltFunctionalTestModel);
            if (eltFunctionalTestModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",eltFunctionalTestViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", eltFunctionalTestViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",eltFunctionalTestViewModel.UserId);
            return View(eltFunctionalTestViewModel);
        }

        // POST: EltFunctionalTest/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EltFunctionalTestViewModel eltFunctionalTestViewModel)
        {
            if (ModelState.IsValid)
            {
                EltFunctionalTestModel eltFunctionalTestModel = eltFunctionalTestService.GetEltFunctionalTest(eltFunctionalTestViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(eltFunctionalTestViewModel, eltFunctionalTestModel);
                eltFunctionalTestService.SaveEltFunctionalTest();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", eltFunctionalTestViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", eltFunctionalTestViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", eltFunctionalTestViewModel.UserId);
            return View(eltFunctionalTestViewModel);
        }

        // GET: EltFunctionalTest/Delete/5

        // POST: EltFunctionalTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            EltFunctionalTestModel eltFunctionalTestModel = eltFunctionalTestService.GetEltFunctionalTest(id);
            eltFunctionalTestService.DeleteEltFunctionalTest(eltFunctionalTestModel);
            eltFunctionalTestService.SaveEltFunctionalTest();
            return RedirectToAction("Index");
        }


    }
}
