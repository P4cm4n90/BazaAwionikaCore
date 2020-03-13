using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class OxygenCylinderPortableRepository : RepositoryBase<OxygenCylinderPortableModel>, IOxygenCylinderPortableRepository
    {
        public OxygenCylinderPortableRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    public interface IOxygenCylinderPortableRepository : IRepository<OxygenCylinderPortableModel>
    {

    }
}
    