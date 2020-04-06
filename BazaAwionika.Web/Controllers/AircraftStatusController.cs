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
    public class AircraftStatusController : Controller
    {
        private readonly IAircraftStatusService aircraftStatusService;

        public AircraftStatusController(IAircraftStatusService aircraftStatusService)
        {
            this.aircraftStatusService = aircraftStatusService;
        }

        // GET: AircraftStatusModels
        public IActionResult Index()
        {
            IEnumerable<AircraftStatusModel> aircraftStatusModels;
            IEnumerable<AircraftStatusViewModel> aircraftStatusViewModels;

            aircraftStatusModels = aircraftStatusService.GetAircraftStatuses();
            aircraftStatusViewModels = AutoMapperConfiguration.Mapper.Map<IEnumerable<AircraftStatusModel>, IEnumerable<AircraftStatusViewModel>>(aircraftStatusModels);

            return View(aircraftStatusViewModels);
        }

        // GET: AircraftStatusModels/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                     return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            AircraftStatusModel aircraftStatusModel = aircraftStatusService.GetAircraftStatus(id);
            AircraftStatusViewModel aircraftStatusViewModel = AutoMapperConfiguration.Mapper.Map<AircraftStatusViewModel>(aircraftStatusModel);
            if (aircraftStatusModel == null)           
                return new StatusCodeResult(StatusCodes.Status404NotFound);;           
            return View(aircraftStatusViewModel);
        }

        // GET: AircraftStatusModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AircraftStatusModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AircraftStatusViewModel aircraftStatusViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftStatusModel aircraftStatusModel = AutoMapperConfiguration.Mapper.Map<AircraftStatusModel>(aircraftStatusViewModel);
                aircraftStatusService.CreateAircraftStatus(aircraftStatusModel);
                aircraftStatusService.SaveAircraftStatus();
                return RedirectToAction("Index");
            }

            return View(aircraftStatusViewModel);
        }

        // GET: AircraftStatusModels/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            AircraftStatusModel aircraftStatusModel = aircraftStatusService.GetAircraftStatus(id);
            AircraftStatusViewModel aircraftStatusViewModel = AutoMapperConfiguration.Mapper.Map<AircraftStatusViewModel>(aircraftStatusModel);
            if (aircraftStatusModel == null)         
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            
            return View(aircraftStatusViewModel);
        }

        // POST: AircraftStatusModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AircraftStatusViewModel aircraftStatusViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftStatusModel aircraftStatusModel = aircraftStatusService.GetAircraftStatus(aircraftStatusViewModel.Id);
                aircraftStatusModel = AutoMapperConfiguration.Mapper.Map<AircraftStatusModel>(aircraftStatusViewModel);
                // aircraftStatusService.UpdateAircraftStatus(aircraftStatusModel);
                aircraftStatusService.SaveAircraftStatus();
                return RedirectToAction("Index");
            }
            return View(aircraftStatusViewModel);
        }

        // POST: AircraftStatusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            AircraftStatusModel aircraftStatusModel = aircraftStatusService.GetAircraftStatus(id);
            aircraftStatusService.DeleteAircraftStatus(aircraftStatusModel);
            aircraftStatusService.SaveAircraftStatus();
            return RedirectToAction("Index");
        }
    }
}
