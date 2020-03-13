using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IUlbCvrService
    {
        IEnumerable<UlbCvrModel> GetUlbCvrs();
        UlbCvrModel GetUlbCvr(int id);
        void CreateUlbCvr(UlbCvrModel ulbCvr);
        void SaveUlbCvr();

        void DeleteUlbCvr(UlbCvrModel ulbCvrModel);


    }
    public class UlbCvrService : IUlbCvrService
    {
        private readonly IUlbCvrRepository ulbCvrRepository;
        private readonly IUnitOfWork unitOfWork;

        public UlbCvrService(IUlbCvrRepository ulbCvrRepository, IUnitOfWork unitOfWork)
        {
            this.ulbCvrRepository = ulbCvrRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUlbCvr(UlbCvrModel ulbCvr)
        {
            ulbCvrRepository.Add(ulbCvr);
        }

        public UlbCvrModel GetUlbCvr(int id)
        {
            return ulbCvrRepository.GetById(id);
        }

        public IEnumerable<UlbCvrModel> GetUlbCvrs()
        {
            return ulbCvrRepository.GetAll();
        }

        public void SaveUlbCvr()
        {
            unitOfWork.Commit();
        }

        public void DeleteUlbCvr(UlbCvrModel ulbCvrModel)
        {
            ulbCvrRepository.Delete(ulbCvrModel);
        }
    }
}