using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class FdrReadController : Controller
    {
        private readonly IFdrReadService fdrReadService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public FdrReadController(IFdrReadService fdrReadService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.fdrReadService = fdrReadService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: FdrRead
        public IActionResult Index()
        {
            IEnumerable<FdrReadModel> fdrReadModels;
            IEnumerable<FdrReadViewModel> fdrReadViewModels;
            fdrReadModels = fdrReadService.GetFdrReads();
            fdrReadViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<FdrReadModel>,IEnumerable<FdrReadViewModel>>(fdrReadModels);

            return View(fdrReadViewModels);
        }

        // GET: FdrRead/Details/5
        public IActionResult Details(int id)
        {
            FdrReadModel fdrReadModel = fdrReadService.GetFdrRead(id);
            if (fdrReadModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(fdrReadModel);
        }

        // GET: FdrRead/Create
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

        // POST: FdrRead/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FdrReadViewModel fdrReadViewModel)
        {
            if (ModelState.IsValid)
            {
                var fdrReadModel = AutoMapperConfiguration.Mapper.Map<FdrReadModel>(fdrReadViewModel);
                fdrReadService.CreateFdrRead(fdrReadModel);
                fdrReadService.SaveFdrRead();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(fdrReadViewModel);
        }

        // GET: FdrRead/Edit/5
        public IActionResult Edit(int id)
        {
            FdrReadModel fdrReadModel = fdrReadService.GetFdrRead(id);
            FdrReadViewModel fdrReadViewModel = AutoMapperConfiguration.Mapper.Map<FdrReadViewModel>(fdrReadModel);
            if (fdrReadModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",fdrReadViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", fdrReadViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",fdrReadViewModel.UserId);
            return View(fdrReadViewModel);
        }

        // POST: FdrRead/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FdrReadViewModel fdrReadViewModel)
        {
            if (ModelState.IsValid)
            {
                FdrReadModel fdrReadModel = fdrReadService.GetFdrRead(fdrReadViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<FdrReadModel>(fdrReadViewModel);
                fdrReadService.SaveFdrRead();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", fdrReadViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", fdrReadViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", fdrReadViewModel.UserId);
            return View(fdrReadViewModel);
        }


        // POST: FdrRead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            FdrReadModel fdrReadModel = fdrReadService.GetFdrRead(id);
            fdrReadService.DeleteFdrRead(fdrReadModel);
            fdrReadService.SaveFdrRead();
            return RedirectToAction("Index");
        }


    }
}
