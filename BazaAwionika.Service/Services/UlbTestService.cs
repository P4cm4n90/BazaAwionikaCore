using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IUlbTestService
    {
        IEnumerable<UlbTestModel> GetUlbTests();
        UlbTestModel GetUlbTest(int id);
        void CreateUlbTest(UlbTestModel ulbTest);
        void SaveUlbTest();

        void DeleteUlbTest(UlbTestModel ulbFdrModel);


    }
    public class UlbTestService : IUlbTestService
    {
        private readonly IUlbTestRepository ulbTestRepository;
        private readonly IUnitOfWork unitOfWork;

        public UlbTestService(IUlbTestRepository ulbTestRepository, IUnitOfWork unitOfWork)
        {
            this.ulbTestRepository = ulbTestRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUlbTest(UlbTestModel ulbTest)
        {
            ulbTestRepository.Add(ulbTest);
        }

        public UlbTestModel GetUlbTest(int id)
        {
            return ulbTestRepository.GetById(id);
        }

        public IEnumerable<UlbTestModel> GetUlbTests()
        {
            return ulbTestRepository.GetAll();
        }

        public void SaveUlbTest()
        {
            unitOfWork.Commit();
        }

        public void DeleteUlbTest(UlbTestModel ulbFdrModel)
        {
            ulbTestRepository.Delete(ulbFdrModel);
        }
    }
}