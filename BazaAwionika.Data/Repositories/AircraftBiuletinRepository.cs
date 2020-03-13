using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;


namespace BazaAwionika.Data.Repositories
{
    public class AircraftBiuletinRepository : RepositoryBase<AircraftBiuletinModel>, IAircraftBiuletinRepository
    {
        public AircraftBiuletinRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IAircraftBiuletinRepository : IRepository<AircraftBiuletinModel>
    {

    }
}