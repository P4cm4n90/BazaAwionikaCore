using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class UlbFdrRepository : RepositoryBase<UlbFdrModel>, IUlbFdrRepository
    {
        public UlbFdrRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    public interface IUlbFdrRepository : IRepository<UlbFdrModel>
    {

    }
}