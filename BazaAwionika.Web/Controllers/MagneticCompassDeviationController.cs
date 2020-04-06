using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class MagneticCompassDeviationController : Controller
    {
        private readonly IMagneticCompassDeviationService magneticCompassDeviationService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public MagneticCompassDeviationController(IMagneticCompassDeviationService magneticCompassDeviationService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.magneticCompassDeviationService = magneticCompassDeviationService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: MagneticCompassDeviation
        public IActionResult Index()
        {
            IEnumerable<MagneticCompassDeviationModel> magneticCompassDeviationModels;
            IEnumerable<MagneticCompassDeviationViewModel> magneticCompassDeviationViewModels;
            magneticCompassDeviationModels = magneticCompassDeviationService.GetMagneticCompassDeviations();
            magneticCompassDeviationViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<MagneticCompassDeviationModel>,IEnumerable<MagneticCompassDeviationViewModel>>(magneticCompassDeviationModels);

            return View(magneticCompassDeviationViewModels);
        }

        // GET: MagneticCompassDeviation/Details/5
        public IActionResult Details(int id)
        {
            MagneticCompassDeviationModel magneticCompassDeviationModel = magneticCompassDeviationService.GetMagneticCompassDeviation(id);
            if (magneticCompassDeviationModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(magneticCompassDeviationModel);
        }

        // GET: MagneticCompassDeviation/Create
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

        // POST: MagneticCompassDeviation/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MagneticCompassDeviationViewModel magneticCompassDeviationViewModel)
        {
            if (ModelState.IsValid)
            {
                MagneticCompassDeviationModel magneticCompassDeviationModel = 
                    AutoMapperConfiguration.Mapper.Map<MagneticCompassDeviationModel>(magneticCompassDeviationViewModel);

                magneticCompassDeviationService.CreateMagneticCompassDeviation(magneticCompassDeviationModel);
                magneticCompassDeviationService.SaveMagneticCompassDeviation();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(magneticCompassDeviationViewModel);
        }

        // GET: MagneticCompassDeviation/Edit/5
        public IActionResult Edit(int id)
        {
            MagneticCompassDeviationModel magneticCompassDeviationModel = magneticCompassDeviationService.GetMagneticCompassDeviation(id);
            MagneticCompassDeviationViewModel magneticCompassDeviationViewModel = AutoMapperConfiguration.Mapper.Map<MagneticCompassDeviationViewModel>(magneticCompassDeviationModel);
            if (magneticCompassDeviationModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",magneticCompassDeviationViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", magneticCompassDeviationViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",magneticCompassDeviationViewModel.UserId);
            return View(magneticCompassDeviationViewModel);
        }

        // POST: MagneticCompassDeviation/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MagneticCompassDeviationViewModel magneticCompassDeviationViewModel)
        {
            if (ModelState.IsValid)
            {
                MagneticCompassDeviationModel magneticCompassDeviationModel = magneticCompassDeviationService.GetMagneticCompassDeviation(magneticCompassDeviationViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<MagneticCompassDeviationModel>(magneticCompassDeviationViewModel);
                magneticCompassDeviationService.SaveMagneticCompassDeviation();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", magneticCompassDeviationViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", magneticCompassDeviationViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", magneticCompassDeviationViewModel.UserId);
            return View(magneticCompassDeviationViewModel);
        }



        // POST: MagneticCompassDeviation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            MagneticCompassDeviationModel magneticCompassDeviationModel = magneticCompassDeviationService.GetMagneticCompassDeviation(id);
            magneticCompassDeviationService.DeleteMagneticCompassDeviation(magneticCompassDeviationModel);
            magneticCompassDeviationService.SaveMagneticCompassDeviation();
            return RedirectToAction("Index");
        }


    }
}
