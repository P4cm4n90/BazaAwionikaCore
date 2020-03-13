using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class FlightRepository : RepositoryBase<FlightModel>, IFlightRepository
    {
        public FlightRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IFlightRepository : IRepository<FlightModel>
    {

    }
}