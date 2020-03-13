using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IGeneratorService
    {
        IEnumerable<GeneratorModel> GetGenerators();
        GeneratorModel GetGenerator(int id);
        void CreateGenerator(GeneratorModel generator);

        void UpdateGenerator(GeneratorModel generator);

        void DeleteGenerator(GeneratorModel generator);

        void SaveGenerator();


    }
    public class GeneratorService : IGeneratorService
    {
        private readonly IGeneratorRepository generatorRepository;
        private readonly IUnitOfWork unitOfWork;

        public GeneratorService(IGeneratorRepository generatorRepository, IUnitOfWork unitOfWork)
        {
            this.generatorRepository = generatorRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateGenerator(GeneratorModel generator)
        {
            generatorRepository.Add(generator);
        }

        public void DeleteGenerator(GeneratorModel generator)
        {
            generatorRepository.Delete(generator);
        }

        public GeneratorModel GetGenerator(int id)
        {
            return generatorRepository.GetById(id);
        }

        public IEnumerable<GeneratorModel> GetGenerators()
        {
            return generatorRepository.GetAll();
        }

        public void SaveGenerator()
        {
            unitOfWork.Commit();
        }

        public void UpdateGenerator(GeneratorModel generator)
        {
            generatorRepository.Update(generator);
        }
    }
}