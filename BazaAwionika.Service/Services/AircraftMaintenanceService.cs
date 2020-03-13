using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IAircraftMaintenanceService
    {
        IEnumerable<AircraftMaintenanceModel> GetAircraftMaintenances();
        AircraftMaintenanceModel GetAircraftMaintenance(int id);
        void CreateAircraftMaintenance(AircraftMaintenanceModel aircraftMaintenance);
        void UpdateAircraftMaintenance(AircraftMaintenanceModel aircraftMaintenanceModel);

        void DeleteAircraftMaintenance(AircraftMaintenanceModel aircraftMaintenanceModel);
        void SaveAircraftMaintenance();


    }
    public class AircraftMaintenanceService : IAircraftMaintenanceService
    {
        private readonly IAircraftMaintenanceRepository aircraftMaintenanceRepository;
        private readonly IUnitOfWork unitOfWork;

        public AircraftMaintenanceService(IAircraftMaintenanceRepository aircraftMaintenanceRepository, IUnitOfWork unitOfWork)
        {
            this.aircraftMaintenanceRepository = aircraftMaintenanceRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateAircraftMaintenance(AircraftMaintenanceModel aircraftMaintenance)
        {
            aircraftMaintenanceRepository.Add(aircraftMaintenance);
        }

        public AircraftMaintenanceModel GetAircraftMaintenance(int id)
        {
            return aircraftMaintenanceRepository.GetById(id);
        }

        public IEnumerable<AircraftMaintenanceModel> GetAircraftMaintenances()
        {
            return aircraftMaintenanceRepository.GetAll();
        }

        public void UpdateAircraftMaintenance(AircraftMaintenanceModel aircraftMaintenanceModel)
        {
            aircraftMaintenanceRepository.Update(aircraftMaintenanceModel);
        }

        public void DeleteAircraftMaintenance(AircraftMaintenanceModel aircraftMaintenanceModel)
        {
            aircraftMaintenanceRepository.Delete(aircraftMaintenanceModel);
        }

        public void SaveAircraftMaintenance()
        {
            unitOfWork.Commit();
        }
    }
}