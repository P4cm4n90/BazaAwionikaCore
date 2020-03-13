using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        MaintenanceEntities dbContext;

        public MaintenanceEntities Init()
        {
            return dbContext ?? (dbContext = new MaintenanceEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

            

    }
} 