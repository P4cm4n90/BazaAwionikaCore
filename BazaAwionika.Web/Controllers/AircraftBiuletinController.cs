using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class AircraftBiuletinController : Controller
    {
        private readonly IAircraftBiuletinService aircraftBiuletinService;
        private readonly IAircraftService aircraftService;

        public AircraftBiuletinController(IAircraftBiuletinService aircraftBiuletinService, IAircraftService aircraftService)
        {
            this.aircraftBiuletinService = aircraftBiuletinService;
            this.aircraftService = aircraftService;
        }

        // GET: AircraftBiuletin
        public IActionResult Index()
        {
            var aircraftBiuletinModels = aircraftBiuletinService.GetAircraftBiuletins();
            IEnumerable<AircraftBiuletinViewModel> aircraftBiuletinViewModels =
                AutoMapperConfiguration.Mapper.Map<IEnumerable<AircraftBiuletinModel>,
                IEnumerable<AircraftBiuletinViewModel>>(aircraftBiuletinModels);

            List<AircraftBiuletinsViewModel> aircraftBiuletinsViewModels = new List<AircraftBiuletinsViewModel>();
            return View(aircraftBiuletinViewModels);
        }

        // GET: AircraftBiuletin/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            AircraftBiuletinModel aircraftBiuletinModel = aircraftBiuletinService.GetAircraftBiuletin(id);
            if (aircraftBiuletinModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            AircraftBiuletinViewModel aircraftBiuletinViewModel =
    AutoMapperConfiguration.Mapper.Map<AircraftBiuletinViewModel>(aircraftBiuletinModel);

            return PartialView(aircraftBiuletinViewModel);
        }

        // GET: AircraftBiuletin/Create
        public IActionResult Create()
        {
            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            return View();
        }

        // POST: AircraftBiuletin/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AircraftBiuletinViewModel aircraftBiuletinViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftBiuletinModel aircraftBiuletinModel =
                    AutoMapperConfiguration.Mapper.Map<AircraftBiuletinModel>(aircraftBiuletinViewModel);

                aircraftBiuletinService.CreateAircraftBiuletin(aircraftBiuletinModel);
                aircraftBiuletinService.SaveAircraftBiuletin();
                return RedirectToAction("Index");
            }

            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");

            return View(aircraftBiuletinViewModel);
        }

        // GET: AircraftBiuletin/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);

            AircraftBiuletinModel aircraftBiuletinModel = aircraftBiuletinService.GetAircraftBiuletin(id);
            if (aircraftBiuletinModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            AircraftBiuletinViewModel aircraftBiuletinViewModel =
                AutoMapperConfiguration.Mapper.Map<AircraftBiuletinViewModel>(aircraftBiuletinModel);

            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");

            return View(aircraftBiuletinViewModel);
        }

        // POST: AircraftBiuletin/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AircraftBiuletinViewModel aircraftBiuletinViewModel)
        {
            if (ModelState.IsValid)
            {
                AircraftBiuletinModel aircraftBiuletinModel = aircraftBiuletinService.GetAircraftBiuletin(aircraftBiuletinViewModel.Id);
                aircraftBiuletinModel = AutoMapperConfiguration.Mapper.Map<AircraftBiuletinModel>(aircraftBiuletinViewModel);
                aircraftBiuletinService.UpdateAircraftBiuletin(aircraftBiuletinModel);
                aircraftBiuletinService.SaveAircraftBiuletin();
                return RedirectToAction("Index");
            }
            IEnumerable<AircraftModel> aircraftModels = aircraftService.GetAircrafts();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            return View(aircraftBiuletinViewModel);
        }

        // POST: AircraftBiuletin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            AircraftBiuletinModel aircraftBiuletinModel = aircraftBiuletinService.GetAircraftBiuletin(id);

            aircraftBiuletinService.DeleteAircraftBiuletin(aircraftBiuletinModel);
            aircraftBiuletinService.SaveAircraftBiuletin();
            return RedirectToAction("Index");
        }

    }
}
