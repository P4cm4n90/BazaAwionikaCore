using System.Collections.Generic;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class AircraftsController : Controller
    {
        private readonly IAircraftService aircraftService;
        private readonly IAircraftMaintenanceService aircraftMaintenanceService;
        private readonly IAircraftBiuletinService aircraftBiuletinService;
        private readonly IAircraftStatusService aircraftStatusService;
        private readonly IUserService userService;


        public AircraftsController(IAircraftService aircraftService,
            IAircraftMaintenanceService aircraftMaintenanceService, IUserService userService,
            IAircraftStatusService aircraftStatusService, IAircraftBiuletinService aircraftBiuletinService)
        {
            this.aircraftBiuletinService = aircraftBiuletinService;
            this.aircraftMaintenanceService = aircraftMaintenanceService;
            this.aircraftStatusService = aircraftStatusService;
            this.aircraftService = aircraftService;
            this.userService = userService;
        }
        // GET: Aircrafts
        public IActionResult Index()
        {
            IEnumerable<AircraftModel> aircraftModels;
            IEnumerable<AircraftViewModel> aircraftViewsModels;

            aircraftModels = aircraftService.GetAircrafts();
            aircraftViewsModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<AircraftModel>, IEnumerable<AircraftViewModel>>(aircraftModels);
      
            return View(aircraftViewsModels);
        }

        // GET: Aircrafts/Details/5
        public IActionResult Details(int id)
        {
            //  if (id == null)
            //  {
            //     return new StatusCodeResult(StatusCodes.Status400BadRequest);;
            //  }

            AircraftModel aircraftModel = aircraftService.GetAircraft(id);
            if (aircraftModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            AircraftViewModel aircraftViewModel = AutoMapperConfiguration.Mapper.Map<AircraftViewModel>(aircraftModel);
            return PartialView(aircraftViewModel);
        }

        // GET: Aircrafts/Create
        public IActionResult Create()
        {
            ViewBag.AircraftStatusId = new SelectList(aircraftStatusService.GetAircraftStatuses(), "Id", "Name");
            ViewBag.UserId = new SelectList(userService.GetUsers(), "Id", "Name");
            return View();
        }

        // POST: Aircrafts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AircraftViewModel aircraftViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftModel aircraftModel = AutoMapperConfiguration.Mapper.Map<AircraftModel>(aircraftViewModel);

                aircraftService.CreateAircraft(aircraftModel);
                aircraftService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AircraftStatusId = new SelectList(aircraftStatusService.GetAircraftStatuses(), "Id", "Name");
            ViewBag.UserId = new SelectList(userService.GetUsers(), "Id", "Name");
            return View(aircraftViewModel);
        }

        // GET: Aircrafts/Edit/5
        public IActionResult Edit(int id)
        {
            AircraftModel aircraftModel = aircraftService.GetAircraft(id);
            AircraftViewModel aircraftViewModel = AutoMapperConfiguration.Mapper.Map<AircraftViewModel>(aircraftModel);
      //      AircraftViewModel aircraftViewModel = Auto
            if (aircraftModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;


            ViewBag.AircraftStatusId = new SelectList(aircraftStatusService.GetAircraftStatuses(), "Id", "Name",aircraftModel.AircraftStatusId);
            ViewBag.UserId = new SelectList(userService.GetUsers(), "Id", "Name",aircraftModel.UserId);
            return View(aircraftViewModel);
        }

        // POST: Aircrafts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AircraftViewModel aircraftViewModel)
        {

                if (ModelState.IsValid) //TODO: ogarnac ze statusem
                {
                    AircraftStatusModel status;
                    if (aircraftViewModel.AircraftStatusId != null)
                        status = aircraftStatusService.GetAircraftStatus((int)aircraftViewModel.AircraftStatusId);
                    else
                        status = null;
                    var aircraftModel = aircraftService.GetAircraft(aircraftViewModel.Id);
                    AutoMapperConfiguration.Mapper.Map(aircraftViewModel, aircraftModel);
                    var flightHours = aircraftService.GetFlightHoursChange(aircraftModel);
                    aircraftService.UpdateItemsFlightHours(aircraftModel.Id, flightHours);
                    aircraftService.Save();
                    return RedirectToAction("Index");
                }

            ViewBag.AircraftStatusId = new SelectList(aircraftStatusService.GetAircraftStatuses(), "Id", "Name", aircraftViewModel.AircraftStatusId);
            ViewBag.UserId = new SelectList(userService.GetUsers(), "Id", "Name", aircraftViewModel.UserId);

            return View(aircraftViewModel);
        }



        // POST: Aircrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            aircraftService.DeleteAircraft(id);
            aircraftService.Save();
            return RedirectToAction("Index");
        }

        public IActionResult AircraftStatusesList()
        {
            return RedirectToAction("Index");
        }
    }
}
