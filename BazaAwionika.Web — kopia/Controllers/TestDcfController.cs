using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class TestDcfController : Controller
    {
        private readonly ITestDcfService testDcfService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public TestDcfController(ITestDcfService testDcfService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.testDcfService = testDcfService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: TestDcf
        public IActionResult Index()
        {
            IEnumerable<TestDcfModel> testDcfModels;
            IEnumerable<TestDcfViewModel> testDcfViewModels;
            testDcfModels = testDcfService.GetTestsDcf();
            testDcfViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<TestDcfModel>,IEnumerable<TestDcfViewModel>>(testDcfModels);

            return PartialView(testDcfViewModels);
        }

        // GET: TestDcf/Details/5
        public IActionResult Details(int id)
        {
            TestDcfModel testDcfModel = testDcfService.GetTestDcf(id);
            if (testDcfModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(testDcfModel);
        }

        // GET: TestDcf/Create
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

        // POST: TestDcf/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestDcfViewModel testDcfViewModel)
        {
            if (ModelState.IsValid)
            {
                TestDcfModel testDcfModel = AutoMapperConfiguration.Mapper.Map<TestDcfModel>(testDcfViewModel);

                testDcfService.CreateTestDcf(testDcfModel);
                testDcfService.SaveTestDcf();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(testDcfViewModel);
        }

        // GET: TestDcf/Edit/5
        public IActionResult Edit(int id)
        {
            TestDcfModel testDcfModel = testDcfService.GetTestDcf(id);
            TestDcfViewModel testDcfViewModel = AutoMapperConfiguration.Mapper.Map<TestDcfViewModel>(testDcfModel);
            if (testDcfModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",testDcfViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", testDcfViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",testDcfViewModel.UserId);
            return View(testDcfViewModel);
        }

        // POST: TestDcf/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TestDcfViewModel testDcfViewModel)
        {
            if (ModelState.IsValid)
            {
                TestDcfModel testDcfModel = testDcfService.GetTestDcf(testDcfViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<TestDcfModel>(testDcfViewModel);
                testDcfService.SaveTestDcf();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", testDcfViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", testDcfViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", testDcfViewModel.UserId);
            return View(testDcfViewModel);
        }



        // POST: TestDcf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TestDcfModel testDcfModel = testDcfService.GetTestDcf(id);
            testDcfService.DeleteTestDcf(testDcfModel);
            testDcfService.SaveTestDcf();
            return RedirectToAction("Index");
        }


    }
}
