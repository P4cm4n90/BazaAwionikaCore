using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IGpsBatteriesService
    {
        IEnumerable<GpsBatteriesModel> GetGpsBatteries();
        GpsBatteriesModel GetGpsBatteries(int id);
        void CreateGpsBatteries(GpsBatteriesModel gpsBatteries);
        void SaveGpsBatteries();
        void DeleteGpsBatteries(GpsBatteriesModel gipsenDatabaseModel);


    }
    public class GpsBatteriesService : IGpsBatteriesService
    {
        private readonly IGpsBatteriesRepository gpsBatteriesRepository;
        private readonly IUnitOfWork unitOfWork;

        public GpsBatteriesService(IGpsBatteriesRepository gpsBatteriesRepository, IUnitOfWork unitOfWork)
        {
            this.gpsBatteriesRepository = gpsBatteriesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateGpsBatteries(GpsBatteriesModel gpsBatteries)
        {
            gpsBatteriesRepository.Add(gpsBatteries);
        }

        public GpsBatteriesModel GetGpsBatteries(int id)
        {
            return gpsBatteriesRepository.GetById(id);
        }

        public IEnumerable<GpsBatteriesModel> GetGpsBatteries()
        {
            return gpsBatteriesRepository.GetAll();
        }

        public void SaveGpsBatteries()
        {
            unitOfWork.Commit();
        }

        public void DeleteGpsBatteries(GpsBatteriesModel gipsenDatabaseModel)
        {
            gpsBatteriesRepository.Delete(gipsenDatabaseModel);
        }
    }
}