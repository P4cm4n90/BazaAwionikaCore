using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class EltOperationalTestRepository : RepositoryBase<EltOperationalTestModel>, IEltOperationalTestRepository
    {
        public EltOperationalTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<EltOperationalTestModel> GetByAircraftId (int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }
    }

    public interface IEltOperationalTestRepository : IRepository<EltOperationalTestModel>
    {
        IEnumerable<EltOperationalTestModel> GetByAircraftId (int id);
    }
}