using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class BatteryRepository : RepositoryBase<BatteryModel>, IBatteryRepository
    {
        public BatteryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<BatteryModel>GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }

        public void AddFlightHoursByAircraftId(int aircraftId, int flightHours)
        {
            IEnumerable<BatteryModel> models = GetByAircraftId(aircraftId);
            if (models == null)
                return;

            foreach (BatteryModel alt in models)
            {
                if (alt.IsInstalled)
                {
                    alt.FlightHours = alt.FlightHours + flightHours;
                    base.Update(alt);
                }
            }

        }
    }

    public interface IBatteryRepository : IRepository<BatteryModel>
    {
        IEnumerable<BatteryModel> GetByAircraftId(int id);
        void AddFlightHoursByAircraftId(int aircraftId, int flightHours);
    }
}