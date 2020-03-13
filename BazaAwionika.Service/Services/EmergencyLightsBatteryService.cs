using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IEmergencyLightsBatteryService
    {
        IEnumerable<EmergencyLightsBatteryModel> GetEmergencyLightsBatteries();
        EmergencyLightsBatteryModel GetEmergencyLightsBattery(int id);
        void CreateEmergencyLightsBattery(EmergencyLightsBatteryModel emergencyLightsBattery);
        void SaveEmergencyLightsBattery();

        void DeleteEmergencyLightsBattery(EmergencyLightsBatteryModel emergencyLightsBatteryModel);


    }
    public class EmergencyLightsBatteryService : IEmergencyLightsBatteryService
    {
        private readonly IEmergencyLightsBatteryRepository emergencyLightsBatteryRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmergencyLightsBatteryService(IEmergencyLightsBatteryRepository emergencyLightsBatteryRepository, IUnitOfWork unitOfWork)
        {
            this.emergencyLightsBatteryRepository = emergencyLightsBatteryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEmergencyLightsBattery(EmergencyLightsBatteryModel emergencyLightsBattery)
        {
            emergencyLightsBatteryRepository.Add(emergencyLightsBattery);
        }

        public EmergencyLightsBatteryModel GetEmergencyLightsBattery(int id)
        {
            return emergencyLightsBatteryRepository.GetById(id);
        }

        public IEnumerable<EmergencyLightsBatteryModel> GetEmergencyLightsBatteries()
        {
            return emergencyLightsBatteryRepository.GetAll();
        }

        public void SaveEmergencyLightsBattery()
        {
            unitOfWork.Commit();
        }

        public void DeleteEmergencyLightsBattery(EmergencyLightsBatteryModel emergencyLightsBatteryModel)
        {
            emergencyLightsBatteryRepository.Delete(emergencyLightsBatteryModel);
        }
    }
}