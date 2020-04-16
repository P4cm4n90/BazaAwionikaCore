using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.ViewComponents
{
    public class AircraftListViewComponent : ViewComponent
    {
        private readonly IAircraftService aircraftService;
        public AircraftListViewComponent(IAircraftService aircraftService) : base()
        {
            this.aircraftService = aircraftService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<AircraftModel> aircraftModels;
            IEnumerable<AircraftSmallViewModel> aircraftViewsModels;
            aircraftModels = aircraftService.GetAircrafts();
            aircraftViewsModels = AutoMapperConfiguration.Mapper.
            Map<IEnumerable<AircraftModel>, IEnumerable<AircraftSmallViewModel>>(aircraftModels);
            return View(aircraftViewsModels);
 
        }

    }
}
