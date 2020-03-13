using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class OxygenExchangeRepository : RepositoryBase<OxygenExchangeModel>, IOxygenExchangeRepository
    {
        public OxygenExchangeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    public interface IOxygenExchangeRepository : IRepository<OxygenExchangeModel>
    {

    }
}