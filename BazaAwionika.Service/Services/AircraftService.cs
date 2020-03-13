using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{
    public interface IAircraftService
    {
        IEnumerable<AircraftModel> GetAircrafts();
        AircraftModel GetAircraft(int id);
        void CreateAircraft(AircraftModel aircraft);
        void Save();

        void DeleteAircraft(AircraftModel aircraftModel);
        void DeleteAircraft(int id);

        void UpdateAircraft(AircraftModel aircraft);

        int GetFlightHoursChange(AircraftModel aircraft);

        void UpdateItemsFlightHours(int aircraftId, int flightHours);

        IEnumerable<AircraftMaintenanceModel> GetAircraftMaintenances(AircraftModel aircraft);
        IEnumerable<AircraftBiuletinModel> GetAircraftBiuletins(AircraftModel aircraft);

        DateTime? GetLastUpdateDate();

        



    }
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepository aircraftRepository;
        private readonly IAircraftMaintenanceRepository aircraftMaintenanceRepository;
        private readonly IAircraftBiuletinRepository aircraftBiuletinRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAlternatorRepository alternatorRepository;
        private readonly IBatteryRepository batteryRepository;
        private readonly IGeneratorRepository generatorRepository;

        

        public AircraftService(IAircraftRepository aircraftRepository, IAircraftBiuletinRepository aircraftBiuletinRepository,
            IAircraftMaintenanceRepository aircraftMaintenanceRepository, 
            IUserRepository userRepository, IUnitOfWork unitOfWork, IAlternatorRepository alternatorRepository,
            IBatteryRepository batteryRepository, IEltOperationalTestRepository eltOperationalTestRepository,
            IGeneratorRepository generatorRepository, 
            IFdrReadRepository fdrReadRepository, ITestTruRepository testTruRepository,
            ITestEfisRepository testEfisRepository, ITestDcfRepository testDcfRepository)
        {

            this.aircraftRepository = aircraftRepository;
            this.aircraftBiuletinRepository = aircraftBiuletinRepository;
            this.aircraftMaintenanceRepository = aircraftMaintenanceRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.alternatorRepository = alternatorRepository;
            this.generatorRepository = generatorRepository;
            this.batteryRepository = batteryRepository;
 
        }

        #region IAircraftService Members
        public IEnumerable<AircraftModel> GetAircrafts()
        {
            var aircrafts = aircraftRepository.GetAll();
            return aircrafts;
        }


        /// <summary>
        /// No tracking is set
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AircraftModel GetAircraft(int id)
        {
            return aircraftRepository.GetById(id);
        }

        public void CreateAircraft(AircraftModel aircraft)
        {
            aircraftRepository.Add(aircraft);
        }
        /// <summary>
        /// Returns value that represents how much flight hours were added
        /// </summary>
        /// <param name="aircraft"></param>
        /// 

        public void UpdateAircraft(AircraftModel aircraft)
        {
            aircraftRepository.Update(aircraft);
        }

        public int GetFlightHoursChange(AircraftModel aircraft)
        {
            
            var flightHours = aircraft.FlightHours - aircraftRepository.GetByIdNoTracking(aircraft.Id).FlightHours;
            return flightHours;
        }

        public void DeleteAircraft(AircraftModel aircraftModel)
        {
            aircraftRepository.Delete(aircraftModel);
        }

        public void DeleteAircraft(int id)
        {
            aircraftRepository.Delete(aircraftRepository.GetById(id));
        }



        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<AircraftMaintenanceModel> GetAircraftMaintenances(AircraftModel aircraft)
        {
            return aircraftMaintenanceRepository.GetMany(c => c.AircraftId == aircraft.Id);
        }

        public IEnumerable<AircraftBiuletinModel> GetAircraftBiuletins(AircraftModel aircraft)
        {
            return aircraftBiuletinRepository.GetMany(c => c.AircraftId == aircraft.Id);
        }

        public DateTime? GetLastUpdateDate()
        {
            return aircraftRepository.GetAll().Max(p => p.DateAdd);
        }


       public void UpdateItemsFlightHours(int aircraftId, int flightHours)
        {

            alternatorRepository.AddFlightHoursByAircraftId(aircraftId, flightHours);
            batteryRepository.AddFlightHoursByAircraftId(aircraftId, flightHours);
            generatorRepository.AddFlightHoursByAircraftId(aircraftId, flightHours);
        }

        #endregion
    }
}