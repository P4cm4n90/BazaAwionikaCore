﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class CountryRepository : RepositoryBase<CountryModel>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ICountryRepository : IRepository<CountryModel>
    {

    }
}