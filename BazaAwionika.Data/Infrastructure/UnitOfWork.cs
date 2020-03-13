using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MaintenanceEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory) => this.dbFactory = dbFactory;

        public MaintenanceEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
