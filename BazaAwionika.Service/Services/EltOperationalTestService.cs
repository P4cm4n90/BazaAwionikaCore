using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IEltOperationalTestService
    {
        IEnumerable<EltOperationalTestModel> GetEltOperationalTests();
        EltOperationalTestModel GetEltOperationalTest(int id);
        void CreateEltOperationalTest(EltOperationalTestModel eltOperationalTest);
        void SaveEltOperationalTest();
        void DeleteEltOperationalTest(EltOperationalTestModel eltOperationalTestModel);


    }
    public class EltOperationalTestService : IEltOperationalTestService
    {
        private readonly IEltOperationalTestRepository eltOperationalTestRepository;
        private readonly IUnitOfWork unitOfWork;

        public EltOperationalTestService(IEltOperationalTestRepository eltOperationalTestRepository, IUnitOfWork unitOfWork)
        {
            this.eltOperationalTestRepository = eltOperationalTestRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEltOperationalTest(EltOperationalTestModel eltOperationalTest)
        {
            eltOperationalTestRepository.Add(eltOperationalTest);
        }

        public EltOperationalTestModel GetEltOperationalTest(int id)
        {
            return eltOperationalTestRepository.GetById(id);
        }

        public IEnumerable<EltOperationalTestModel> GetEltOperationalTests()
        {
            return eltOperationalTestRepository.GetAll();
        }

        public void SaveEltOperationalTest()
        {
            unitOfWork.Commit();
        }

        public void DeleteEltOperationalTest(EltOperationalTestModel eltOperationalTestModel)
        {
            eltOperationalTestRepository.Delete(eltOperationalTestModel);
        }
    }
}