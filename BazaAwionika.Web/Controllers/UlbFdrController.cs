using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.Controllers
{
    public class UlbFdrController : Controller
    {
        private readonly IUlbFdrService ulbFdrService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public UlbFdrController(IUlbFdrService ulbFdrService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.ulbFdrService = ulbFdrService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: UlbFdr
        public IActionResult Index()
        {
            IEnumerable<UlbFdrModel> ulbFdrModels;
            IEnumerable<UlbFdrViewModel> ulbFdrViewModels;
            ulbFdrModels = ulbFdrService.GetUlbFdrs();
            ulbFdrViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<UlbFdrModel>,IEnumerable<UlbFdrViewModel>>(ulbFdrModels);

            return View(ulbFdrViewModels);
        }

        // GET: UlbFdr/Details/5
        public IActionResult Details(int id)
        {
            UlbFdrModel ulbFdrModel = ulbFdrService.GetUlbFdr(id);
            if (ulbFdrModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(ulbFdrModel);
        }

        // GET: UlbFdr/Create
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

        // POST: UlbFdr/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UlbFdrViewModel ulbFdrViewModel)
        {
            if (ModelState.IsValid)
            {
                UlbFdrModel ulbFdrModel = AutoMapperConfiguration.Mapper.Map<UlbFdrModel>(ulbFdrViewModel);

                ulbFdrService.CreateUlbFdr(ulbFdrModel);
                ulbFdrService.SaveUlbFdr();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(ulbFdrViewModel);
        }

        // GET: UlbFdr/Edit/5
        public IActionResult Edit(int id)
        {
            UlbFdrModel ulbFdrModel = ulbFdrService.GetUlbFdr(id);
            UlbFdrViewModel ulbFdrViewModel = AutoMapperConfiguration.Mapper.Map<UlbFdrViewModel>(ulbFdrModel);
            if (ulbFdrModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",ulbFdrViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", ulbFdrViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",ulbFdrViewModel.UserId);
            return View(ulbFdrViewModel);
        }

        // POST: UlbFdr/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UlbFdrViewModel ulbFdrViewModel)
        {
            if (ModelState.IsValid)
            {
                UlbFdrModel ulbFdrModel = ulbFdrService.GetUlbFdr(ulbFdrViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(ulbFdrViewModel, ulbFdrModel);
                ulbFdrService.SaveUlbFdr();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", ulbFdrViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", ulbFdrViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", ulbFdrViewModel.UserId);
            return View(ulbFdrViewModel);
        }



        // POST: UlbFdr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            UlbFdrModel ulbFdrModel = ulbFdrService.GetUlbFdr(id);
            ulbFdrService.DeleteUlbFdr(ulbFdrModel);
            ulbFdrService.SaveUlbFdr();
            return RedirectToAction("Index");
        }


    }
}
