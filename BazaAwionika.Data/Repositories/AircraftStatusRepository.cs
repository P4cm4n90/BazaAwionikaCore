using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;


namespace BazaAwionika.Data.Repositories
{
    public class AircraftStatusRepository : RepositoryBase<AircraftStatusModel>, IAircraftStatusRepository
    {
        public AircraftStatusRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IAircraftStatusRepository : IRepository<AircraftStatusModel>
    {
        
    }

}