﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class EltFunctionalTestRepository : RepositoryBase<EltFunctionalTestModel>, IEltFunctionalTestRepository
    {
        public EltFunctionalTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IEltFunctionalTestRepository : IRepository<EltFunctionalTestModel>
    {

    }
}