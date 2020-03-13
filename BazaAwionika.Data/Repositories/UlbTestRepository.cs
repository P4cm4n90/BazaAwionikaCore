using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class UlbTestRepository : RepositoryBase<UlbTestModel>, IUlbTestRepository
    {
        public UlbTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    public interface IUlbTestRepository : IRepository<UlbTestModel>
    {

    }
}