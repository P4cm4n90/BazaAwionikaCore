using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class OxygenCylinderMainRepository : RepositoryBase<OxygenCylinderMainModel>, IOxygenCylinderMainRepository
    {
        public OxygenCylinderMainRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IOxygenCylinderMainRepository : IRepository<OxygenCylinderMainModel>
    {

    }
}