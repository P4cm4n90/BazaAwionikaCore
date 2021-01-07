using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.Controllers
{
    public class TestEfisController : Controller
    {
        private readonly ITestEfisService testEfisService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public TestEfisController(ITestEfisService testEfisService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.testEfisService = testEfisService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: TestEfis
        public IActionResult Index()
        {
            IEnumerable<TestEfisModel> testEfisModels;
            IEnumerable<TestEfisViewModel> testEfisViewModels;
            testEfisModels = testEfisService.GetTestsEfis();
            testEfisViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<TestEfisModel>,IEnumerable<TestEfisViewModel>>(testEfisModels);

            return PartialView(testEfisViewModels);
        }

        // GET: TestEfis/Details/5
        public IActionResult Details(int id)
        {
            TestEfisModel testEfisModel = testEfisService.GetTestEfis(id);
            if (testEfisModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(testEfisModel);
        }

        // GET: TestEfis/Create
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

        // POST: TestEfis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestEfisViewModel testEfisViewModel)
        {
            if (ModelState.IsValid)
            {
                TestEfisModel testEfisModel = AutoMapperConfiguration.Mapper.Map<TestEfisModel>(testEfisViewModel);
                testEfisService.CreateTestEfis(testEfisModel);
                testEfisService.SaveTestEfis();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(testEfisViewModel);
        }

        // GET: TestEfis/Edit/5
        public IActionResult Edit(int id)
        {
            TestEfisModel testEfisModel = testEfisService.GetTestEfis(id);
            TestEfisViewModel testEfisViewModel = AutoMapperConfiguration.Mapper.Map<TestEfisViewModel>(testEfisModel);
            if (testEfisModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",testEfisViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", testEfisViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",testEfisViewModel.UserId);
            return View(testEfisViewModel);
        }

        // POST: TestEfis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TestEfisViewModel testEfisViewModel)
        {
            if (ModelState.IsValid)
            {
                TestEfisModel testEfisModel = testEfisService.GetTestEfis(testEfisViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(testEfisViewModel, testEfisModel);
                testEfisService.SaveTestEfis();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", testEfisViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", testEfisViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", testEfisViewModel.UserId);
            return View(testEfisViewModel);
        }


        // POST: TestEfis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TestEfisModel testEfisModel = testEfisService.GetTestEfis(id);
            testEfisService.DeleteTestEfis(testEfisModel);
            testEfisService.SaveTestEfis();
            return RedirectToAction("Index");
        }


    }
}
