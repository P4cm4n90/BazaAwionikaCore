using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class EmergencyLightsBatteryRepository : RepositoryBase<EmergencyLightsBatteryModel>, IEmergencyLightsBatteryRepository
    {
        public EmergencyLightsBatteryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IEmergencyLightsBatteryRepository : IRepository<EmergencyLightsBatteryModel>
    {

    }
}