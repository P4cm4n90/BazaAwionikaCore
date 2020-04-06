using System.Collections.Generic;
using System.Net;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class AircraftMaintenanceController : Controller
    {
        private readonly IAircraftMaintenanceService aircraftMaintenanceService;
        private readonly IAircraftService aircraftService;

        public AircraftMaintenanceController(IAircraftMaintenanceService aircraftMaintenanceService, IAircraftService aircraftService)
        {
            this.aircraftMaintenanceService = aircraftMaintenanceService;
            this.aircraftService = aircraftService;
        }

        // GET: AircraftMaintenance
        public IActionResult Index()
        {
            var aircraftMaintenanceModels = aircraftMaintenanceService.GetAircraftMaintenances();
            IEnumerable<AircraftMaintenanceViewModel> aircraftMaintenanceViewModels =
                AutoMapperConfiguration.Mapper.Map<IEnumerable<AircraftMaintenanceModel>, 
                IEnumerable<AircraftMaintenanceViewModel>>(aircraftMaintenanceModels);
            return View(aircraftMaintenanceViewModels);
        }

        // GET: AircraftMaintenance/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            AircraftMaintenanceModel aircraftMaintenanceModel = aircraftMaintenanceService.GetAircraftMaintenance(id);
            if (aircraftMaintenanceModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            AircraftMaintenanceViewModel aircraftMaintenanceViewModel =
    AutoMapperConfiguration.Mapper.Map<AircraftMaintenanceViewModel>(aircraftMaintenanceModel);

            return PartialView(aircraftMaintenanceViewModel);
        }

        // GET: AircraftMaintenance/Create
        public IActionResult Create()
        {
            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            return View();
        }

        // POST: AircraftMaintenance/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AircraftMaintenanceViewModel aircraftMaintenanceViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftMaintenanceModel aircraftMaintenanceModel = 
                    AutoMapperConfiguration.Mapper.Map<AircraftMaintenanceModel>(aircraftMaintenanceViewModel);

                aircraftMaintenanceService.CreateAircraftMaintenance(aircraftMaintenanceModel);
                aircraftMaintenanceService.SaveAircraftMaintenance();
                return RedirectToAction("Index");
            }

            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");

            return View(aircraftMaintenanceViewModel);
        }

        // GET: AircraftMaintenance/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            AircraftMaintenanceModel aircraftMaintenanceModel = aircraftMaintenanceService.GetAircraftMaintenance(id);
            if (aircraftMaintenanceModel == null)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            AircraftMaintenanceViewModel aircraftMaintenanceViewModel = 
                AutoMapperConfiguration.Mapper.Map<AircraftMaintenanceViewModel>(aircraftMaintenanceModel);

            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");

            return View(aircraftMaintenanceViewModel);
        }

        // POST: AircraftMaintenance/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AircraftMaintenanceViewModel aircraftMaintenanceViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftMaintenanceModel aircraftMaintenanceModel = aircraftMaintenanceService.GetAircraftMaintenance(aircraftMaintenanceViewModel.Id);
                aircraftMaintenanceModel = AutoMapperConfiguration.Mapper.Map<AircraftMaintenanceModel>(aircraftMaintenanceViewModel);
                aircraftMaintenanceService.UpdateAircraftMaintenance(aircraftMaintenanceModel);
                aircraftMaintenanceService.SaveAircraftMaintenance();
                return RedirectToAction("Index");
            }
            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            return View(aircraftMaintenanceViewModel);
        }

        // POST: AircraftMaintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            AircraftMaintenanceModel aircraftMaintenanceModel = aircraftMaintenanceService.GetAircraftMaintenance(id);

            aircraftMaintenanceService.DeleteAircraftMaintenance(aircraftMaintenanceModel);
            aircraftMaintenanceService.SaveAircraftMaintenance();
            return RedirectToAction("Index");
        }

    }
}
