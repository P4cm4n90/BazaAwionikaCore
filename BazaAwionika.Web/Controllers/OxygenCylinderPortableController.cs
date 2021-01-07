using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;


namespace BazaAwionika.Web.Controllers
{
    public class OxygenCylinderPortableController : Controller
    {
        private readonly IOxygenCylinderPortableService oxygenCylinderPortableService;
        private readonly IAircraftService aircraftService;
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public OxygenCylinderPortableController(IOxygenCylinderPortableService oxygenCylinderPortableService, IAircraftService aircraftService, ISettingsService settingsService,
            IUserService userService)
        {
            this.oxygenCylinderPortableService = oxygenCylinderPortableService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: OxygenCylinderPortable
        public IActionResult Index()
        {
            IEnumerable<OxygenCylinderPortableModel> oxygenCylinderPortables;
            IEnumerable<OxygenCylinderPortableViewModel> oxygenCylinderPortablesVM;
            oxygenCylinderPortables = oxygenCylinderPortableService.GetOxygenCylinderPortables();
            oxygenCylinderPortablesVM = AutoMapperConfiguration.Mapper.Map<IEnumerable<OxygenCylinderPortableModel>, IEnumerable<OxygenCylinderPortableViewModel>>(oxygenCylinderPortables);
            return View(oxygenCylinderPortablesVM);

        }

        // GET: OxygenCylinderPortable/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            OxygenCylinderPortableModel oxygenCylinderPortableModel = oxygenCylinderPortableService.GetOxygenCylinderPortable(id);
            if (oxygenCylinderPortableModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            OxygenCylinderPortableViewModel oxygenCylinderPortableViewModel = AutoMapperConfiguration.Mapper.Map<OxygenCylinderPortableModel, OxygenCylinderPortableViewModel>(oxygenCylinderPortableModel);

            return View(oxygenCylinderPortableViewModel);
        }

        // GET: OxygenCylinderPortable/Create
        public IActionResult Create()
        {
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return PartialView();
        }

        // POST: OxygenCylinderPortable/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OxygenCylinderPortableViewModel oxygenCylinderPortableViewModel)
        {
            if (ModelState.IsValid)
            {
                OxygenCylinderPortableModel oxygenCylinderPortableModel 
                    = AutoMapperConfiguration.Mapper.Map<OxygenCylinderPortableModel>(oxygenCylinderPortableViewModel);

                oxygenCylinderPortableService.CreateOxygenCylinderPortable(oxygenCylinderPortableModel);
                oxygenCylinderPortableService.SaveOxygenCylinderPortable();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");

            return View(oxygenCylinderPortableViewModel);
        }

        // GET: OxygenCylinderPortable/Edit/5
        public IActionResult Edit(int id)
        {
            OxygenCylinderPortableModel oxygenCylinderPortableModel = oxygenCylinderPortableService.GetOxygenCylinderPortable(id);
            OxygenCylinderPortableViewModel oxygenCylinderPortableViewModel = AutoMapperConfiguration.Mapper.Map<OxygenCylinderPortableViewModel>(oxygenCylinderPortableModel);
            if (oxygenCylinderPortableModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", oxygenCylinderPortableViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", oxygenCylinderPortableViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", oxygenCylinderPortableViewModel.UserId);

            return View(oxygenCylinderPortableViewModel);
        }

        // POST: OxygenCylinderPortable/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OxygenCylinderPortableViewModel oxygenCylinderPortableViewModel)
        {
            if (ModelState.IsValid)
            {
                OxygenCylinderPortableModel oxygenCylinderPortableModel = oxygenCylinderPortableService.GetOxygenCylinderPortable(oxygenCylinderPortableViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(oxygenCylinderPortableViewModel, oxygenCylinderPortableModel);
                oxygenCylinderPortableService.SaveOxygenCylinderPortable();
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", oxygenCylinderPortableViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", oxygenCylinderPortableViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", oxygenCylinderPortableViewModel.UserId);
            return View(oxygenCylinderPortableViewModel);
        }



        // POST: OxygenCylinderPortable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            OxygenCylinderPortableModel oxygenCylinderPortableModel = oxygenCylinderPortableService.GetOxygenCylinderPortable(id);

            oxygenCylinderPortableService.DeleteOxygenCylinderPortable(oxygenCylinderPortableModel);
            oxygenCylinderPortableService.SaveOxygenCylinderPortable();
            return RedirectToAction("Index");
        }


    }
}

