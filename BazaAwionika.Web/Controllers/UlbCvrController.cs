using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.Controllers
{
    public class UlbCvrController : Controller
    {
        private readonly IUlbCvrService ulbCvrService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public UlbCvrController(IUlbCvrService ulbCvrService, IUserService userService, ISettingsService settingsService, IAircraftService aircraftService)
        {
            this.ulbCvrService = ulbCvrService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: UlbCvr
        public IActionResult Index()
        {
            IEnumerable<UlbCvrModel> ulbCvrModels;
            IEnumerable<UlbCvrViewModel> ulbCvrViewModels;
            ulbCvrModels = ulbCvrService.GetUlbCvrs();
            ulbCvrViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<UlbCvrModel>,IEnumerable<UlbCvrViewModel>>(ulbCvrModels);

            return View(ulbCvrViewModels);
        }

        // GET: UlbCvr/Details/5
        public IActionResult Details(int id)
        {
            UlbCvrModel ulbCvrModel = ulbCvrService.GetUlbCvr(id);
            if (ulbCvrModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return PartialView(ulbCvrModel);
        }

        // GET: UlbCvr/Create
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

        // POST: UlbCvr/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UlbCvrViewModel ulbCvrViewModel)
        {
            if (ModelState.IsValid)
            {
                UlbCvrModel ulbCvrModel = AutoMapperConfiguration.Mapper.Map<UlbCvrModel>(ulbCvrViewModel);
                ulbCvrService.CreateUlbCvr(ulbCvrModel);
                ulbCvrService.SaveUlbCvr();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");
            return View(ulbCvrViewModel);
        }

        // GET: UlbCvr/Edit/5
        public IActionResult Edit(int id)
        {
            UlbCvrModel ulbCvrModel = ulbCvrService.GetUlbCvr(id);
            UlbCvrViewModel ulbCvrViewModel = AutoMapperConfiguration.Mapper.Map<UlbCvrViewModel>(ulbCvrModel);
            if (ulbCvrModel == null)          
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber",ulbCvrViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", ulbCvrViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name",ulbCvrViewModel.UserId);
            return View(ulbCvrViewModel);
        }

        // POST: UlbCvr/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UlbCvrViewModel ulbCvrViewModel)
        {
            if (ModelState.IsValid)
            {
                UlbCvrModel ulbCvrModel = ulbCvrService.GetUlbCvr(ulbCvrViewModel.Id);
                AutoMapperConfiguration.Mapper.Map<UlbCvrModel>(ulbCvrViewModel);
                ulbCvrService.SaveUlbCvr();
                    
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", ulbCvrViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", ulbCvrViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", ulbCvrViewModel.UserId);
            return View(ulbCvrViewModel);
        }



        // POST: UlbCvr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            UlbCvrModel ulbCvrModel = ulbCvrService.GetUlbCvr(id);
            ulbCvrService.DeleteUlbCvr(ulbCvrModel);
            ulbCvrService.SaveUlbCvr();
            return RedirectToAction("Index");
        }


    }
}
