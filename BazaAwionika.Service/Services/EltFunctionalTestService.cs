using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IEltFunctionalTestService
    {
        IEnumerable<EltFunctionalTestModel> GetEltFunctionalTests();
        EltFunctionalTestModel GetEltFunctionalTest(int id);
        void CreateEltFunctionalTest(EltFunctionalTestModel eltFunctionalTest);
        void SaveEltFunctionalTest();

        void DeleteEltFunctionalTest(EltFunctionalTestModel eltFunctionalTestModel);


    }
    public class EltFunctionalTestService : IEltFunctionalTestService
    {
        private readonly IEltFunctionalTestRepository eltFunctionalTestRepository;
        private readonly IUnitOfWork unitOfWork;

        public EltFunctionalTestService(IEltFunctionalTestRepository eltFunctionalTestRepository, IUnitOfWork unitOfWork)
        {
            this.eltFunctionalTestRepository = eltFunctionalTestRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEltFunctionalTest(EltFunctionalTestModel eltFunctionalTest)
        {
            eltFunctionalTestRepository.Add(eltFunctionalTest);
        }

        public EltFunctionalTestModel GetEltFunctionalTest(int id)
        {
            return eltFunctionalTestRepository.GetById(id);
        }

        public IEnumerable<EltFunctionalTestModel> GetEltFunctionalTests()
        {
            return eltFunctionalTestRepository.GetAll();
        }

        public void SaveEltFunctionalTest()
        {
            unitOfWork.Commit();
        }

        public void DeleteEltFunctionalTest(EltFunctionalTestModel eltFunctionalTestModel)
        {
            eltFunctionalTestRepository.Delete(eltFunctionalTestModel);
        }
    }
}