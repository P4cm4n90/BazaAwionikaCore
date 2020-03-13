using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class GeneratorRepository : RepositoryBase<GeneratorModel>, IGeneratorRepository
    {
        public GeneratorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<GeneratorModel>GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }

        public void AddFlightHoursByAircraftId(int aircraftId, int flightHours)
        {
            IEnumerable<GeneratorModel> models = GetByAircraftId(aircraftId).Where(c => c.IsInstalled);
            if (models == null)
                return;

            foreach (GeneratorModel alt in models)
            {
                 alt.FlightHours = alt.FlightHours + flightHours;
                 base.Update(alt);
            }

        }

    }

    public interface IGeneratorRepository : IRepository<GeneratorModel>
    {
        IEnumerable<GeneratorModel>GetByAircraftId(int id);
        void AddFlightHoursByAircraftId(int aircraftId, int flightHours);
    }
}