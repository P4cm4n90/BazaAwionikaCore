using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface ITestDcfService
    {
        IEnumerable<TestDcfModel> GetTestsDcf();
        TestDcfModel GetTestDcf(int id);
        void CreateTestDcf(TestDcfModel testDcf);
        void SaveTestDcf();

        void DeleteTestDcf(TestDcfModel testDcfModel);


    }
    public class TestDcfService : ITestDcfService
    {
        private readonly ITestDcfRepository testDcfRepository;
        private readonly IUnitOfWork unitOfWork;

        public TestDcfService(ITestDcfRepository testDcfRepository, IUnitOfWork unitOfWork)
        {
            this.testDcfRepository = testDcfRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTestDcf(TestDcfModel testDcf)
        {
            testDcfRepository.Add(testDcf);
        }

        public void DeleteTestDcf(TestDcfModel testDcfModel)
        {
            testDcfRepository.Delete(testDcfModel);
        }

        public TestDcfModel GetTestDcf(int id)
        {
            return testDcfRepository.GetById(id);
        }

        public IEnumerable<TestDcfModel> GetTestsDcf()
        {
            return testDcfRepository.GetAll();
        }

        public void SaveTestDcf()
        {
            unitOfWork.Commit();
        }
    }
}