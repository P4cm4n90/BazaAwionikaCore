using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class AircraftMaintenanceRepository : RepositoryBase<AircraftMaintenanceModel>, IAircraftMaintenanceRepository
    {
        public AircraftMaintenanceRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IAircraftMaintenanceRepository : IRepository<AircraftMaintenanceModel>
    {

    }
}


