using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;


namespace BazaAwionika.Web.Controllers
{
    public class OxygenExchangeController : Controller
    {
        private readonly IOxygenExchangeService oxygenExchangeService;
        private readonly IAircraftService aircraftService;
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public OxygenExchangeController(IOxygenExchangeService oxygenExchangeService, IAircraftService aircraftService, ISettingsService settingsService,
            IUserService userService)
        {
            this.oxygenExchangeService = oxygenExchangeService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
        }

        // GET: OxygenExchange
        public IActionResult Index()
        {
            IEnumerable<OxygenExchangeModel> oxygenExchanges;
            IEnumerable<OxygenExchangeViewModel> oxygenExchangesVM;
            oxygenExchanges = oxygenExchangeService.GetOxygenExchanges();
            oxygenExchangesVM = AutoMapperConfiguration.Mapper.Map<IEnumerable<OxygenExchangeModel>, IEnumerable<OxygenExchangeViewModel>>(oxygenExchanges);
            return PartialView(oxygenExchangesVM);

        }

        // GET: OxygenExchange/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            OxygenExchangeModel oxygenExchangeModel = oxygenExchangeService.GetOxygenExchange(id);
            if (oxygenExchangeModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            OxygenExchangeViewModel oxygenExchangeViewModel = AutoMapperConfiguration.Mapper.Map<OxygenExchangeModel, OxygenExchangeViewModel>(oxygenExchangeModel);

            return View(oxygenExchangeViewModel);
        }

        // GET: OxygenExchange/Create
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

        // POST: OxygenExchange/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OxygenExchangeViewModel oxygenExchangeViewModel)
        {
            if (ModelState.IsValid)
            {
                OxygenExchangeModel oxygenExchangeModel = 
                    AutoMapperConfiguration.Mapper.Map<OxygenExchangeModel>(oxygenExchangeViewModel);

                oxygenExchangeService.CreateOxygenExchange(oxygenExchangeModel);
                oxygenExchangeService.SaveOxygenExchange();
                return RedirectToAction("Index");
            }

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber");
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName");
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name");

            return View(oxygenExchangeViewModel);
        }

        // GET: OxygenExchange/Edit/5
        public IActionResult Edit(int id)
        {
            OxygenExchangeModel oxygenExchangeModel = oxygenExchangeService.GetOxygenExchange(id);
            OxygenExchangeViewModel oxygenExchangeViewModel = AutoMapperConfiguration.Mapper.Map<OxygenExchangeViewModel>(oxygenExchangeModel);
            if (oxygenExchangeModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;

            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", oxygenExchangeViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", oxygenExchangeViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", oxygenExchangeViewModel.UserId);

            return View(oxygenExchangeViewModel);
        }

        // POST: OxygenExchange/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OxygenExchangeViewModel oxygenExchangeViewModel)
        {
            if (ModelState.IsValid)
            {
                OxygenExchangeModel oxygenExchangeModel = oxygenExchangeService.GetOxygenExchange(oxygenExchangeViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(oxygenExchangeViewModel, oxygenExchangeModel);
                oxygenExchangeService.SaveOxygenExchange();
                return RedirectToAction("Index");
            }
            var aircraftModels = aircraftService.GetAircrafts();
            var settingsModels = settingsService.GetSettings();
            var usersModels = userService.GetUsers();
            ViewBag.AircraftId = new SelectList(aircraftModels, "Id", "TailNumber", oxygenExchangeViewModel.AircraftId);
            ViewBag.SettingsId = new SelectList(settingsModels, "Id", "SettingsName", oxygenExchangeViewModel.SettingsId);
            ViewBag.UserId = new SelectList(usersModels, "Id", "Name", oxygenExchangeViewModel.UserId);
            return View(oxygenExchangeViewModel);
        }



        // POST: OxygenExchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            OxygenExchangeModel oxygenExchangeModel = oxygenExchangeService.GetOxygenExchange(id);

            oxygenExchangeService.DeleteOxygenExchange(oxygenExchangeModel);
            oxygenExchangeService.SaveOxygenExchange();
            return RedirectToAction("Index");
        }


    }
}

