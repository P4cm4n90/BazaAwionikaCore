using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class FdrReadRepository : RepositoryBase<FdrReadModel>, IFdrReadRepository
    {
        public FdrReadRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<FdrReadModel>GetByAircraftId(int id)
        {
            return base.GetMany(c => c.Aircraft.Id == id);
        }


    }

    public interface IFdrReadRepository : IRepository<FdrReadModel>
    {
        IEnumerable<FdrReadModel>GetByAircraftId(int id);
    }

}