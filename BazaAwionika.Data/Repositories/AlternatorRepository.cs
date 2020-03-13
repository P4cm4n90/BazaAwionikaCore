using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class AlternatorRepository : RepositoryBase<AlternatorModel>, IAlternatorRepository
    {
        public AlternatorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<AlternatorModel> GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }

        public void AddFlightHoursByAircraftId(int aircraftId, int flightHours)
        {
            IEnumerable<AlternatorModel> alternatorModels = GetByAircraftId(aircraftId);
            if (alternatorModels == null)
                return;

            foreach(AlternatorModel alt in alternatorModels)
            {
                if (alt.IsInstalled)
                {
                    alt.FlightHours = alt.FlightHours + flightHours;
                    base.Update(alt);
                }
            }

        }
    }

    public interface IAlternatorRepository : IRepository<AlternatorModel>
    {
        IEnumerable<AlternatorModel> GetByAircraftId(int id);
        void AddFlightHoursByAircraftId(int aircraftId, int flightHour);
    }
}