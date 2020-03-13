using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class MagneticCompassDeviationRepository : RepositoryBase<MagneticCompassDeviationModel>, IMagneticCompassDeviationRepository
    {
        public MagneticCompassDeviationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IMagneticCompassDeviationRepository : IRepository<MagneticCompassDeviationModel>
    {

    }
}