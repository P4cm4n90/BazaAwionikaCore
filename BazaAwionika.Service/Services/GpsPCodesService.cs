using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IGpsPCodesService
    {
        IEnumerable<GpsPCodesModel> GetGpsPCodes();
        GpsPCodesModel GetGpsPCodes(int id);
        void CreateGpsPCodes(GpsPCodesModel gpsPCodes);
        void SaveGpsPCodes();
        void DeleteGpsPCodes(GpsPCodesModel gpsPCodesModel);


    }
    public class GpsPCodesService : IGpsPCodesService
    {
        private readonly IGpsPCodesRepository gpsPCodesRepository;
        private readonly IUnitOfWork unitOfWork;

        public GpsPCodesService(IGpsPCodesRepository gpsPCodesRepository, IUnitOfWork unitOfWork)
        {
            this.gpsPCodesRepository = gpsPCodesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateGpsPCodes(GpsPCodesModel gpsPCodes)
        {
            gpsPCodesRepository.Add(gpsPCodes);
        }

        public GpsPCodesModel GetGpsPCodes(int id)
        {
            return gpsPCodesRepository.GetById(id);
        }

        public IEnumerable<GpsPCodesModel> GetGpsPCodes()
        {
            return gpsPCodesRepository.GetAll();
        }

        public void SaveGpsPCodes()
        {
            unitOfWork.Commit();
        }

        public void DeleteGpsPCodes(GpsPCodesModel gpsPCodesModel)
        {
            gpsPCodesRepository.Delete(gpsPCodesModel);
        }
    }
}