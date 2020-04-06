using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;


namespace BazaAwionika.Web.Controllers
{
    public class OxygenCylinderMainController : Controller
    {
        private readonly IOxygenCylinderMainService oxygenCylinderMainService;
        private readonly IAircraftService aircraftService;
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public OxygenCylinderMainController(IOxygenCylinderMainService oxygenCylinderMainService, IAircraftService aircraftService, ISettingsService settingsService,
            IUserService userService)
        {
            this.oxygenCylinderMainService = oxygenCylinderMainService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: OxygenCylinderMain
        public IActionResult Index()
        {
            IEnumerable<OxygenCylinderMainModel> oxygenCylinderMains;
            IEnumerable<OxygenCylinderMainViewModel> oxygenCylinderMainsVM;
            oxygenCylinderMains = oxygenCylinderMainService.GetOxygenCylindersMain();
            oxygenCylinderMainsVM = AutoMapperConfiguration.Mapper.Map<IEnumerable<OxygenCylinderMainModel>, IEnumerable<OxygenCylinderMainViewModel>>(oxygenCylinderMains);
            return PartialView(oxygenCylinderMainsVM);

        }

        // GET: OxygenCylinderMain/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            OxygenCylinderMainModel oxygenCylinderMainModel = oxygenCylinderMainService.GetOxygenCylinderMain(id);
            if (oxygenCylinderMainModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            OxygenCylinderMainViewModel oxygenCylinderMainViewModel = AutoMapperConfiguration.Mapper.Map<OxygenCylinderMainModel, OxygenCylinderMainViewModel>(oxygenCylinderMainModel);

            return View(oxygenCylinderMainViewModel);
        }

        // GET: OxygenCylinderMain/Create
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

        // POST: OxygenCylinderMain/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OxygenCylinderMainViewModel oxygenCylinderMainViewModel)
        {
            if (ModelState.IsValid)
            {
                OxygenCylinderMainModel oxygenCylinderMainModel = 
                    AutoMapperConfiguration.Mapper.Map<OxygenCylinderMainModel>(oxygenCylinderMainViewModel);

                oxygenCylinderMainService.CreateOxygenCylinderMain(oxygenCylinderMainModel);
                oxygenCylinderMainService.SaveOxygenCylinderMain();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");

            return View(oxygenCylinderMainViewModel);
        }

        // GET: OxygenCylinderMain/Edit/5
        public IActionResult Edit(int id)
        {
            OxygenCylinderMainModel oxygenCylinderMainModel = oxygenCylinderMainService.GetOxygenCylinderMain(id);
            OxygenCylinderMainViewModel oxygenCylinderMainViewModel = AutoMapperConfiguration.Mapper.Map<OxygenCylinderMainViewModel>(oxygenCylinderMainModel);
            if (oxygenCylinderMainModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", oxygenCylinderMainViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", oxygenCylinderMainViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", oxygenCylinderMainViewModel.UserId);

            return View(oxygenCylinderMainViewModel);
        }

        // POST: OxygenCylinderMain/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OxygenCylinderMainViewModel oxygenCylinderMainViewModel)
        {
            if (ModelState.IsValid)
            {
                OxygenCylinderMainModel oxygenCylinderMainModel = oxygenCylinderMainService.GetOxygenCylinderMain(oxygenCylinderMainViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<OxygenCylinderMainModel>(oxygenCylinderMainViewModel);
                oxygenCylinderMainService.SaveOxygenCylinderMain();
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", oxygenCylinderMainViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", oxygenCylinderMainViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", oxygenCylinderMainViewModel.UserId);
            return View(oxygenCylinderMainViewModel);
        }



        // POST: OxygenCylinderMain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            OxygenCylinderMainModel oxygenCylinderMainModel = oxygenCylinderMainService.GetOxygenCylinderMain(id);

            oxygenCylinderMainService.DeleteOxygenCylinderMain(oxygenCylinderMainModel);
            oxygenCylinderMainService.SaveOxygenCylinderMain();
            return RedirectToAction("Index");
        }


    }
}

