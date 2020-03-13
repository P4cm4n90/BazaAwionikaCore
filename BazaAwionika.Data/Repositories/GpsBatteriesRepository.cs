using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class GpsBatteriesRepository : RepositoryBase<GpsBatteriesModel>, IGpsBatteriesRepository
    {
        public GpsBatteriesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IGpsBatteriesRepository : IRepository<GpsBatteriesModel>
    {

    }
}