using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IAircraftStatusService
    {
        IEnumerable<AircraftStatusModel> GetAircraftStatuses();
        AircraftStatusModel GetAircraftStatus(int id);
        void CreateAircraftStatus(AircraftStatusModel aircraftStatus);
        void SaveAircraftStatus();

        void DeleteAircraftStatus(AircraftStatusModel aircraftStatusModel);
        void UpdateAircraftStatus(AircraftStatusModel aircraftStatusModel);


    }
    public class AircraftStatusService : IAircraftStatusService
    {
        private readonly IAircraftStatusRepository aircraftStatusRepository;
        private readonly IUnitOfWork unitOfWork;

        public AircraftStatusService(IAircraftStatusRepository aircraftStatusRepository, IUnitOfWork unitOfWork)
        {
            this.aircraftStatusRepository = aircraftStatusRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateAircraftStatus(AircraftStatusModel aircraftStatus)
        {
            aircraftStatusRepository.Add(aircraftStatus);
        }

        public AircraftStatusModel GetAircraftStatus(int id)
        {
            return aircraftStatusRepository.GetById(id);
        }

        public IEnumerable<AircraftStatusModel> GetAircraftStatuses()
        {
            return aircraftStatusRepository.GetAll();
        }

        public void UpdateAircraftStatus(AircraftStatusModel aircraftStatus)
        {
            aircraftStatusRepository.Update(aircraftStatus);
        }

        public void DeleteAircraftStatus(AircraftStatusModel aircraftStatusModel)
        {
            aircraftStatusRepository.Delete(aircraftStatusModel);
        }

        public void SaveAircraftStatus()
        {
            unitOfWork.Commit();
        }
    }
}