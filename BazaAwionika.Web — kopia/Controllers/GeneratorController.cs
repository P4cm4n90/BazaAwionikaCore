using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;


namespace BazaAwionika.Web.Controllers
{
    public class GeneratorController : Controller
    {
        private readonly IGeneratorService generatorService;
        private readonly IAircraftService aircraftService;
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public GeneratorController(IGeneratorService generatorService, IAircraftService aircraftService, ISettingsService settingsService,
            IUserService userService)
        {
            this.generatorService = generatorService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: Generator
        public IActionResult Index()
        {
            IEnumerable<GeneratorModel> generators;
            IEnumerable<GeneratorViewModel> generatorsVM;
            generators = generatorService.GetGenerators();
            generatorsVM = AutoMapperConfiguration.Mapper.Map<IEnumerable<GeneratorModel>, IEnumerable<GeneratorViewModel>>(generators);
            return View(generatorsVM);

        }

        // GET: Generator/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            GeneratorModel generatorModel = generatorService.GetGenerator(id);
            if (generatorModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            GeneratorViewModel generatorViewModel = AutoMapperConfiguration.Mapper.Map<GeneratorModel, GeneratorViewModel>(generatorModel);

            return PartialView(generatorViewModel);
        }

        // GET: Generator/Create
        public IActionResult Create()
        {
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UsersId = new SelectList(usersModels, "Id", "Name");
            return View();
        }

        // POST: Generator/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GeneratorViewModel generatorViewModel)
        {
            if (ModelState.IsValid)
            {
                var generatorModel = AutoMapperConfiguration.Mapper.Map<GeneratorModel>(generatorViewModel);
                generatorService.CreateGenerator(generatorModel);
                generatorService.SaveGenerator();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");

            return View(generatorViewModel);
        }

        // GET: Generator/Edit/5
        public IActionResult Edit(int id)
        {
            GeneratorModel generatorModel = generatorService.GetGenerator(id);
            GeneratorViewModel generatorViewModel = AutoMapperConfiguration.Mapper.Map<GeneratorViewModel>(generatorModel);
            if (generatorModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",generatorViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", generatorViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", generatorViewModel.UserId);

            return View(generatorViewModel);
        }

        // POST: Generator/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GeneratorViewModel generatorViewModel)
        {
            if (ModelState.IsValid)
            {
                GeneratorModel generatorModel = generatorService.GetGenerator(generatorViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(generatorViewModel, generatorModel);
                generatorService.SaveGenerator();
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", generatorViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", generatorViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", generatorViewModel.UserId);
            return View(generatorViewModel);
        }



        // POST: Generator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            GeneratorModel generatorModel = generatorService.GetGenerator(id);

            generatorService.DeleteGenerator(generatorModel);
            generatorService.SaveGenerator();
            return RedirectToAction("Index");
        }


    }
}

