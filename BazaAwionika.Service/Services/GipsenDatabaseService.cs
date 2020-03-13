using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IGipsenDatabaseService
    {
        IEnumerable<GipsenDatabaseModel> GetGipsenDatabases();
        GipsenDatabaseModel GetGipsenDatabase(int id);
        void CreateGipsenDatabase(GipsenDatabaseModel gipsenDatabase);
        void SaveGipsenDatabase();
        void DeleteGipsenDatabase(GipsenDatabaseModel gipsenDatabaseModel);


    }
    public class GipsenDatabaseService : IGipsenDatabaseService
    {
        private readonly IGipsenDatabaseRepository gipsenDatabaseRepository;
        private readonly IUnitOfWork unitOfWork;

        public GipsenDatabaseService(IGipsenDatabaseRepository gipsenDatabaseRepository, IUnitOfWork unitOfWork)
        {
            this.gipsenDatabaseRepository = gipsenDatabaseRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateGipsenDatabase(GipsenDatabaseModel gipsenDatabase)
        {
            gipsenDatabaseRepository.Add(gipsenDatabase);
        }

        public GipsenDatabaseModel GetGipsenDatabase(int id)
        {
            return gipsenDatabaseRepository.GetById(id);
        }

        public IEnumerable<GipsenDatabaseModel> GetGipsenDatabases()
        {
            return gipsenDatabaseRepository.GetAll();
        }

        public void SaveGipsenDatabase()
        {
            unitOfWork.Commit();
        }

        public void DeleteGipsenDatabase(GipsenDatabaseModel gipsenDatabaseModel)
        {
            gipsenDatabaseRepository.Delete(gipsenDatabaseModel);
        }
    }
}