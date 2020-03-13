using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface ICountryService
    {
        IEnumerable<CountryModel> GetCountries();
        CountryModel GetCountry(int id);
        void CreateCountry(CountryModel country);
        void SaveCountry();


    }
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateCountry(CountryModel country)
        {
            countryRepository.Add(country);
        }

        public CountryModel GetCountry(int id)
        {
            return countryRepository.GetById(id);
        }

        public IEnumerable<CountryModel> GetCountries()
        {
            return countryRepository.GetAll();
        }

        public void SaveCountry()
        {
            unitOfWork.Commit();
        }
    }
}