using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface ITestEfisService
    {
        IEnumerable<TestEfisModel> GetTestsEfis();
        TestEfisModel GetTestEfis(int id);
        void CreateTestEfis(TestEfisModel testEfis);
        void SaveTestEfis();

        void DeleteTestEfis(TestEfisModel testEfisModel);


    }
    public class TestEfisService : ITestEfisService
    {
        private readonly ITestEfisRepository testEfisRepository;
        private readonly IUnitOfWork unitOfWork;

        public TestEfisService(ITestEfisRepository testEfisRepository, IUnitOfWork unitOfWork)
        {
            this.testEfisRepository = testEfisRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTestEfis(TestEfisModel testEfis)
        {
            testEfisRepository.Add(testEfis);
        }

        public TestEfisModel GetTestEfis(int id)
        {
            return testEfisRepository.GetById(id);
        }

        public IEnumerable<TestEfisModel> GetTestsEfis()
        {
            return testEfisRepository.GetAll();
        }

        public void SaveTestEfis()
        {
            unitOfWork.Commit();
        }

        public void DeleteTestEfis(TestEfisModel testEfisModel)
        {
            testEfisRepository.Delete(testEfisModel);
        }
    }
}