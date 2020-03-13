using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class TestEfisRepository : RepositoryBase<TestEfisModel>, ITestEfisRepository
    {
        public TestEfisRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<TestEfisModel> GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }

    }
    public interface ITestEfisRepository : IRepository<TestEfisModel>
    {
        IEnumerable<TestEfisModel> GetByAircraftId(int id);


    }
}