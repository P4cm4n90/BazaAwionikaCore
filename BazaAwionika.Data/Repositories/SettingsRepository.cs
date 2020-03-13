using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class SettingsRepository : RepositoryBase<SettingsModel>, ISettingsRepository
    {
        public SettingsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
    public interface ISettingsRepository : IRepository<SettingsModel>
    {

    }
}