using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class TestTruRepository : RepositoryBase<TestTruModel>, ITestTruRepository
    {
        public TestTruRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<TestTruModel> GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }


    }

    public interface ITestTruRepository : IRepository<TestTruModel>
    {
             IEnumerable<TestTruModel> GetByAircraftId(int id);

    }
}