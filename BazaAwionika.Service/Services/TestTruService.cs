using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface ITestTruService
    {
        IEnumerable<TestTruModel> GetTestsTru();
        TestTruModel GetTestTru(int id);
        void CreateTestTru(TestTruModel testTru);
        void SaveTestTru();

        void DeleteTestTru(TestTruModel testTruModel);


    }
    public class TestTruService : ITestTruService
    {
        private readonly ITestTruRepository testTruRepository;
        private readonly IUnitOfWork unitOfWork;

        public TestTruService(ITestTruRepository testTruRepository, IUnitOfWork unitOfWork)
        {
            this.testTruRepository = testTruRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTestTru(TestTruModel testTru)
        {
            testTruRepository.Add(testTru);
        }

        public TestTruModel GetTestTru(int id)
        {
            return testTruRepository.GetById(id);
        }

        public IEnumerable<TestTruModel> GetTestsTru()
        {
            return testTruRepository.GetAll();
        }

        public void SaveTestTru()
        {
            unitOfWork.Commit();
        }

        public void DeleteTestTru(TestTruModel testTruModel)
        {
            testTruRepository.Delete(testTruModel);
        }
    }
}