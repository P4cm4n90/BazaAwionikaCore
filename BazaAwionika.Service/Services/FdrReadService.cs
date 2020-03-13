using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IFdrReadService
    {
        IEnumerable<FdrReadModel> GetFdrReads();
        FdrReadModel GetFdrRead(int id);
        void CreateFdrRead(FdrReadModel fdrRead);
        void SaveFdrRead();
        void DeleteFdrRead(FdrReadModel fdrReadModel);


    }
    public class FdrReadService : IFdrReadService
    {
        private readonly IFdrReadRepository fdrReadRepository;
        private readonly IUnitOfWork unitOfWork;

        public FdrReadService(IFdrReadRepository fdrReadRepository, IUnitOfWork unitOfWork)
        {
            this.fdrReadRepository = fdrReadRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateFdrRead(FdrReadModel fdrRead)
        {
            fdrReadRepository.Add(fdrRead);
        }

        public FdrReadModel GetFdrRead(int id)
        {
            return fdrReadRepository.GetById(id);
        }

        public IEnumerable<FdrReadModel> GetFdrReads()
        {
            return fdrReadRepository.GetAll();
        }

        public void SaveFdrRead()
        {
            unitOfWork.Commit();
        }

        public void DeleteFdrRead(FdrReadModel fdrReadModel)
        {
            fdrReadRepository.Delete(fdrReadModel);
        }

    }
}