using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class TestDcfRepository : RepositoryBase<TestDcfModel>, ITestDcfRepository
    {
        public TestDcfRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<TestDcfModel> GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }

    }
    public interface ITestDcfRepository : IRepository<TestDcfModel>
    {
        IEnumerable<TestDcfModel> GetByAircraftId(int id);
    }
}