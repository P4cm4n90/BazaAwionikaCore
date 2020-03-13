using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class GipsenDatabaseRepository : RepositoryBase<GipsenDatabaseModel>, IGipsenDatabaseRepository
    {
        public GipsenDatabaseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IGipsenDatabaseRepository : IRepository<GipsenDatabaseModel>
    {

    }
}