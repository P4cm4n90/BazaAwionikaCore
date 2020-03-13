using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IEgpwsDatabaseService
    {
        IEnumerable<EgpwsDatabaseModel> GetEgpwsDatabases();
        EgpwsDatabaseModel GetEgpwsDatabase(int id);
        void CreateEgpwsDatabase(EgpwsDatabaseModel egpwsDatabase);
        void SaveEgpwsDatabase();
        void DeleteEgpwsDatabase(EgpwsDatabaseModel egpwsDatabaseModel);


    }
    public class EgpwsDatabaseService : IEgpwsDatabaseService
    {
        private readonly IEgpwsDatabaseRepository egpwsDatabaseRepository;
        private readonly IUnitOfWork unitOfWork;

        public EgpwsDatabaseService(IEgpwsDatabaseRepository egpwsDatabaseRepository, IUnitOfWork unitOfWork)
        {
            this.egpwsDatabaseRepository = egpwsDatabaseRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEgpwsDatabase(EgpwsDatabaseModel egpwsDatabase)
        {
            egpwsDatabaseRepository.Add(egpwsDatabase);
        }

        public EgpwsDatabaseModel GetEgpwsDatabase(int id)
        {
            return egpwsDatabaseRepository.GetById(id);
        }

        public IEnumerable<EgpwsDatabaseModel> GetEgpwsDatabases()
        {
            return egpwsDatabaseRepository.GetAll();
        }

        public void SaveEgpwsDatabase()
        {
            unitOfWork.Commit();
        }

        public void DeleteEgpwsDatabase(EgpwsDatabaseModel egpwsDatabaseModel)
        {
            egpwsDatabaseRepository.Delete(egpwsDatabaseModel);
        }
    }
}