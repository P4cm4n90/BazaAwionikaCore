using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAircraftService aircraftService;
        private readonly IAircraftMaintenanceService aircraftMaintenanceService;
        private readonly IAircraftBiuletinService aircraftBiuletinService;
        private readonly IAircraftStatusService aircraftStatusService;

        public HomeController(IAircraftService aircraftService, IAircraftMaintenanceService aircraftMaintenanceService,
            IAircraftStatusService aircraftStatusService, IAircraftBiuletinService aircraftBiuletinService)
        {
            this.aircraftBiuletinService = aircraftBiuletinService;
            this.aircraftMaintenanceService = aircraftMaintenanceService;
            this.aircraftStatusService = aircraftStatusService;
            this.aircraftService = aircraftService;
          //  IEnu
        }


        public IActionResult AircraftList()
        {
            var aircrafts = aircraftService.GetAircrafts();
            IEnumerable<AircraftSmallViewModel> aircraftViewModels = AutoMapperConfiguration.Mapper.
                Map<IEnumerable<AircraftModel>, IEnumerable<AircraftSmallViewModel>>(aircrafts);

            return PartialView("AircraftList", aircraftViewModels);
        }


        /*
        public class HomeController : Controller
        {
            private readonly ICategoryService categoryService;
            private readonly IGadgetService gadgetService;

            public HomeController(ICategoryService categoryService, IGadgetService gadgetService)
            {
                this.categoryService = categoryService;
                this.gadgetService = gadgetService;
            }

            // GET: Home
            public IActionResult Index(string category = null)
            {
                IEnumerable<CategoryViewModel> viewModelGadgets;
                IEnumerable<Category> categories;

                categories = categoryService.GetCategories(category).ToList();

                viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
                return View(viewModelGadgets);
            }
        }*/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}