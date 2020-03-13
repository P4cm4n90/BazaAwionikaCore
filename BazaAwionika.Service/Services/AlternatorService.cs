using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IAlternatorService
    {
        IEnumerable<AlternatorModel> GetAlternators();
        AlternatorModel GetAlternator(int id);

        void CreateAlternator(AlternatorModel alternator);

        void DeleteAlternator(AlternatorModel alternator);
        void UpdateAlternator(AlternatorModel alternator);
        void SaveAlternator();


    }
    public class AlternatorService : IAlternatorService
    {
        private readonly IAlternatorRepository alternatorRepository;
        private readonly IUnitOfWork unitOfWork;

        public AlternatorService(IAlternatorRepository alternatorRepository, IUnitOfWork unitOfWork)
        {
            this.alternatorRepository = alternatorRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateAlternator(AlternatorModel alternator)
        {
            alternatorRepository.Add(alternator);
        }

        public AlternatorModel GetAlternator(int id)
        {
            return alternatorRepository.GetById(id);
        }

        public IEnumerable<AlternatorModel> GetAlternators()
        {
            return alternatorRepository.GetAll();
        }


       public void DeleteAlternator(AlternatorModel alternator)
        {
            alternatorRepository.Delete(alternator);
        }
        public void UpdateAlternator(AlternatorModel alternator)
        {
            alternatorRepository.Update(alternator);
        }
        public void SaveAlternator()
        {
            unitOfWork.Commit();
        }
    }
}