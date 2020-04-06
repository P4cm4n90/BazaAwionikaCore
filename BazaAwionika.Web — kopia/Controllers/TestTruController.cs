using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.Controllers
{
    public class TestTruController : Controller
    {
        private readonly ITestTruService testTruService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public TestTruController(ITestTruService testTruService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.testTruService = testTruService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: TestTru
        public IActionResult Index()
        {
            IEnumerable<TestTruModel> testTruModels;
            IEnumerable<TestTruViewModel> testTruViewModels;
            testTruModels = testTruService.GetTestsTru();
            testTruViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<TestTruModel>,IEnumerable<TestTruViewModel>>(testTruModels);

            return PartialView(testTruViewModels);
        }

        // GET: TestTru/Details/5
        public IActionResult Details(int id)
        {
            TestTruModel testTruModel = testTruService.GetTestTru(id);
            if (testTruModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(testTruModel);
        }

        // GET: TestTru/Create
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

        // POST: TestTru/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestTruViewModel testTruViewModel)
        {
            if (ModelState.IsValid)
            {
                TestTruModel testTruModel = AutoMapperConfiguration.Mapper.Map<TestTruModel>(testTruViewModel);

                testTruService.CreateTestTru(testTruModel);
                testTruService.SaveTestTru();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(testTruViewModel);
        }

        // GET: TestTru/Edit/5
        public IActionResult Edit(int id)
        {
            TestTruModel testTruModel = testTruService.GetTestTru(id);
            TestTruViewModel testTruViewModel = AutoMapperConfiguration.Mapper.Map<TestTruViewModel>(testTruModel);
            if (testTruModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",testTruViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", testTruViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",testTruViewModel.UserId);
            return View(testTruViewModel);
        }

        // POST: TestTru/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TestTruViewModel testTruViewModel)
        {
            if (ModelState.IsValid)
            {
                TestTruModel testTruModel = testTruService.GetTestTru(testTruViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<TestTruModel>(testTruViewModel);
                testTruService.SaveTestTru();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", testTruViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", testTruViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", testTruViewModel.UserId);
            return View(testTruViewModel);
        }


        // POST: TestTru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TestTruModel testTruModel = testTruService.GetTestTru(id);
            testTruService.DeleteTestTru(testTruModel);
            testTruService.SaveTestTru();
            return RedirectToAction("Index");
        }


    }
}
