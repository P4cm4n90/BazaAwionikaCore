using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class UlbCvrRepository : RepositoryBase<UlbCvrModel>, IUlbCvrRepository
    {
        public UlbCvrRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    public interface IUlbCvrRepository : IRepository<UlbCvrModel>
    {

    }
}