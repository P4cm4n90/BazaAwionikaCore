using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.Controllers
{
    public class UlbTestController : Controller
    {
        private readonly IUlbTestService ulbTestService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public UlbTestController(IUlbTestService ulbTestService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.ulbTestService = ulbTestService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: UlbTest
        public IActionResult Index()
        {
            IEnumerable<UlbTestModel> ulbTestModels;
            IEnumerable<UlbTestViewModel> ulbTestViewModels;
            ulbTestModels = ulbTestService.GetUlbTests();
            ulbTestViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<UlbTestModel>,IEnumerable<UlbTestViewModel>>(ulbTestModels);

            return View(ulbTestViewModels);
        }

        // GET: UlbTest/Details/5
        public IActionResult Details(int id)
        {
            UlbTestModel ulbTestModel = ulbTestService.GetUlbTest(id);
            if (ulbTestModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(ulbTestModel);
        }

        // GET: UlbTest/Create
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

        // POST: UlbTest/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UlbTestViewModel ulbTestViewModel)
        {
            if (ModelState.IsValid)
            {
                UlbTestModel ulbTestModel = AutoMapperConfiguration.Mapper.Map<UlbTestModel>(ulbTestViewModel);

                ulbTestService.CreateUlbTest(ulbTestModel);
                ulbTestService.SaveUlbTest();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(ulbTestViewModel);
        }

        // GET: UlbTest/Edit/5
        public IActionResult Edit(int id)
        {
            UlbTestModel ulbTestModel = ulbTestService.GetUlbTest(id);
            UlbTestViewModel ulbTestViewModel = AutoMapperConfiguration.Mapper.Map<UlbTestViewModel>(ulbTestModel);
            if (ulbTestModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",ulbTestViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", ulbTestViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",ulbTestViewModel.UserId);
            return View(ulbTestViewModel);
        }

        // POST: UlbTest/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UlbTestViewModel ulbTestViewModel)
        {
            if (ModelState.IsValid)
            {
                UlbTestModel ulbTestModel = ulbTestService.GetUlbTest(ulbTestViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(ulbTestViewModel, ulbTestModel);
                ulbTestService.SaveUlbTest();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", ulbTestViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", ulbTestViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", ulbTestViewModel.UserId);
            return View(ulbTestViewModel);
        }



        // POST: UlbTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            UlbTestModel ulbTestModel = ulbTestService.GetUlbTest(id);
            ulbTestService.DeleteUlbTest(ulbTestModel);
            ulbTestService.SaveUlbTest();
            return RedirectToAction("Index");
        }


    }
}
