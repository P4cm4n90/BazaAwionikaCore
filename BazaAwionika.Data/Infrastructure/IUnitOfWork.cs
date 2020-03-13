using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}