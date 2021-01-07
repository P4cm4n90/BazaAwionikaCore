using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class PbeController : Controller
    {
        private readonly IPbeService pbeService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public PbeController(IPbeService pbeService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.pbeService = pbeService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: Pbe
        public IActionResult Index()
        {
            IEnumerable<PbeModel> pbeModels;
            IEnumerable<PbeViewModel> pbeViewModels;
            pbeModels = pbeService.GetPbes();
            pbeViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<PbeModel>,IEnumerable<PbeViewModel>>(pbeModels);

            return View(pbeViewModels);
        }

        // GET: Pbe/Details/5
        public IActionResult Details(int id)
        {
            PbeModel pbeModel = pbeService.GetPbe(id);
            if (pbeModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(pbeModel);
        }

        // GET: Pbe/Create
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

        // POST: Pbe/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PbeViewModel pbeViewModel)
        {
            if (ModelState.IsValid)
            {
                PbeModel pbeModel = AutoMapperConfiguration.Mapper.Map<PbeModel>(pbeViewModel);

                pbeService.CreatePbe(pbeModel);
                pbeService.SavePbe();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(pbeViewModel);
        }

        // GET: Pbe/Edit/5
        public IActionResult Edit(int id)
        {
            PbeModel pbeModel = pbeService.GetPbe(id);
            PbeViewModel pbeViewModel = AutoMapperConfiguration.Mapper.Map<PbeViewModel>(pbeModel);
            if (pbeModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",pbeViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", pbeViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",pbeViewModel.UserId);
            return View(pbeViewModel);
        }

        // POST: Pbe/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PbeViewModel pbeViewModel)
        {
            if (ModelState.IsValid)
            {
                PbeModel pbeModel = pbeService.GetPbe(pbeViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(pbeViewModel, pbeModel);
                pbeService.SavePbe();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", pbeViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", pbeViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", pbeViewModel.UserId);
            return View(pbeViewModel);
        }



        // POST: Pbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PbeModel pbeModel = pbeService.GetPbe(id);
            pbeService.DeletePbe(pbeModel);
            pbeService.SavePbe();
            return RedirectToAction("Index");
        }


    }
}
