using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MaintenanceEntities Init();
    }
}