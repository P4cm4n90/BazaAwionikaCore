using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IAircraftBiuletinService
    {
        IEnumerable<AircraftBiuletinModel> GetAircraftBiuletins();
        AircraftBiuletinModel GetAircraftBiuletin(int id);
        void CreateAircraftBiuletin(AircraftBiuletinModel aircraftBiuletin);
        void UpdateAircraftBiuletin(AircraftBiuletinModel aircraftBiuletinModel);

        void DeleteAircraftBiuletin(AircraftBiuletinModel aircraftBiuletinModel);
        void SaveAircraftBiuletin();


    }
    public class AircraftBiuletinService : IAircraftBiuletinService
    {
        private readonly IAircraftBiuletinRepository aircraftBiuletinRepository;
        private readonly IUnitOfWork unitOfWork;

        public AircraftBiuletinService(IAircraftBiuletinRepository aircraftBiuletinRepository, IUnitOfWork unitOfWork)
        {
            this.aircraftBiuletinRepository = aircraftBiuletinRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateAircraftBiuletin(AircraftBiuletinModel aircraftBiuletin)
        {
            aircraftBiuletinRepository.Add(aircraftBiuletin);
        }

        public AircraftBiuletinModel GetAircraftBiuletin(int id)
        {
            return aircraftBiuletinRepository.GetById(id);
        }

        public IEnumerable<AircraftBiuletinModel> GetAircraftBiuletins()
        {
            return aircraftBiuletinRepository.GetAll();
        }

        public void UpdateAircraftBiuletin(AircraftBiuletinModel aircraftBiuletinModel)
        {
            aircraftBiuletinRepository.Update(aircraftBiuletinModel);
        }

        public void DeleteAircraftBiuletin(AircraftBiuletinModel aircraftBiuletinModel)
        {
            aircraftBiuletinRepository.Delete(aircraftBiuletinModel);
        }

        public void SaveAircraftBiuletin()
        {
            unitOfWork.Commit();
        }
    }
}