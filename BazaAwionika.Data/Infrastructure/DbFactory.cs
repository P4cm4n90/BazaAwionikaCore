using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private readonly IConfiguration configuration;
        MaintenanceEntities dbContext;

        public DbFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MaintenanceEntities Init()
        {
            return dbContext ?? (dbContext = new MaintenanceEntities(configuration));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

            

    }
} 