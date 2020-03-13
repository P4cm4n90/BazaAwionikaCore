using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IPbeService
    {
        IEnumerable<PbeModel> GetPbes();
        PbeModel GetPbe(int id);
        void CreatePbe(PbeModel pbe);
        void SavePbe();

        void DeletePbe(PbeModel pbeModel);


    }
    public class PbeService : IPbeService
    {
        private readonly IPbeRepository pbeRepository;
        private readonly IUnitOfWork unitOfWork;

        public PbeService(IPbeRepository pbeRepository, IUnitOfWork unitOfWork)
        {
            this.pbeRepository = pbeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePbe(PbeModel pbe)
        {
            pbeRepository.Add(pbe);
        }

        public PbeModel GetPbe(int id)
        {
            return pbeRepository.GetById(id);
        }

        public IEnumerable<PbeModel> GetPbes()
        {
            return pbeRepository.GetAll();
        }

        public void SavePbe()
        {
            unitOfWork.Commit();
        }

        public void DeletePbe(PbeModel pbeModel)
        {
            pbeRepository.Delete(pbeModel);
        }
    }
}