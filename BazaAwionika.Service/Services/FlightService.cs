using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IFlightService
    {
        IEnumerable<FlightModel> GetFlights();
        FlightModel GetFlight(int id);
        void CreateFlight(FlightModel gipsenDatabase);
        void SaveFlight();


    }
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository flightRepository;
        private readonly IUnitOfWork unitOfWork;

        public FlightService(IFlightRepository flightRepository, IUnitOfWork unitOfWork)
        {
            this.flightRepository = flightRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateFlight(FlightModel gipsenDatabase)
        {
            flightRepository.Add(gipsenDatabase);
        }

        public FlightModel GetFlight(int id)
        {
            return flightRepository.GetById(id);
        }

        public IEnumerable<FlightModel> GetFlights()
        {
            return flightRepository.GetAll();
        }

        public void SaveFlight()
        {
            unitOfWork.Commit();
        }
    }
}