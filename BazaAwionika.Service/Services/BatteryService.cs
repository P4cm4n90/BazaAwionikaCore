using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IBatteryService
    {
        IEnumerable<BatteryModel> GetBatteries();
        BatteryModel GetBattery(int id);
        void CreateBattery(BatteryModel battery);
        void DeleteBattery(BatteryModel battery);
        void UpdateBattery(BatteryModel battery);
        void SaveBattery();


    }
    public class BatteryService : IBatteryService
    {
        private readonly IBatteryRepository batteryRepository;
        private readonly IUnitOfWork unitOfWork;

        public BatteryService(IBatteryRepository batteryRepository, IUnitOfWork unitOfWork)
        {
            this.batteryRepository = batteryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateBattery(BatteryModel battery)
        {
            batteryRepository.Add(battery);
        }

        public BatteryModel GetBattery(int id)
        {
            return batteryRepository.GetById(id);
        }

        public IEnumerable<BatteryModel> GetBatteries()
        {
            return batteryRepository.GetAll();
        }

        public void DeleteBattery(BatteryModel battery)
        {
            batteryRepository.Delete(battery);
        }
        public void UpdateBattery(BatteryModel battery)
        {
            batteryRepository.Update(battery);
        }

        public void SaveBattery()
        {
            unitOfWork.Commit();
        }
    }
}