using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IUlbFdrService
    {
        IEnumerable<UlbFdrModel> GetUlbFdrs();
        UlbFdrModel GetUlbFdr(int id);
        void CreateUlbFdr(UlbFdrModel ulbFdr);
        void SaveUlbFdr();
        void DeleteUlbFdr(UlbFdrModel ulbFdrModel);

    }
    public class UlbFdrService : IUlbFdrService
    {
        private readonly IUlbFdrRepository ulbFdrRepository;
        private readonly IUnitOfWork unitOfWork;

        public UlbFdrService(IUlbFdrRepository ulbFdrRepository, IUnitOfWork unitOfWork)
        {
            this.ulbFdrRepository = ulbFdrRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUlbFdr(UlbFdrModel ulbFdr)
        {
            ulbFdrRepository.Add(ulbFdr);
        }

        public UlbFdrModel GetUlbFdr(int id)
        {
            return ulbFdrRepository.GetById(id);
        }

        public IEnumerable<UlbFdrModel> GetUlbFdrs()
        {
            return ulbFdrRepository.GetAll();
        }

        public void SaveUlbFdr()
        {
            unitOfWork.Commit();
        }

        public void DeleteUlbFdr(UlbFdrModel ulbFdrModel)
        {
            ulbFdrRepository.Delete(ulbFdrModel);
        }
    }
}