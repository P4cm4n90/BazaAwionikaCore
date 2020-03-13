using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IMagneticCompassDeviationService
    {
        IEnumerable<MagneticCompassDeviationModel> GetMagneticCompassDeviations();
        MagneticCompassDeviationModel GetMagneticCompassDeviation(int id);
        void CreateMagneticCompassDeviation(MagneticCompassDeviationModel magneticCompassDeviation);
        void SaveMagneticCompassDeviation();
        void DeleteMagneticCompassDeviation(MagneticCompassDeviationModel magneticCompassDeviationModel);

    }
    public class MagneticCompassDeviationService : IMagneticCompassDeviationService
    {
        private readonly IMagneticCompassDeviationRepository magneticCompassDeviationRepository;
        private readonly IUnitOfWork unitOfWork;

        public MagneticCompassDeviationService(IMagneticCompassDeviationRepository magneticCompassDeviationRepository, IUnitOfWork unitOfWork)
        {
            this.magneticCompassDeviationRepository = magneticCompassDeviationRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateMagneticCompassDeviation(MagneticCompassDeviationModel magneticCompassDeviation)
        {
            magneticCompassDeviationRepository.Add(magneticCompassDeviation);
        }

        public MagneticCompassDeviationModel GetMagneticCompassDeviation(int id)
        {
            return magneticCompassDeviationRepository.GetById(id);
        }

        public IEnumerable<MagneticCompassDeviationModel> GetMagneticCompassDeviations()
        {
            return magneticCompassDeviationRepository.GetAll();
        }

        public void SaveMagneticCompassDeviation()
        {
            unitOfWork.Commit();
        }

        public void DeleteMagneticCompassDeviation(MagneticCompassDeviationModel magneticCompassDeviationModel)
        {
            magneticCompassDeviationRepository.Delete(magneticCompassDeviationModel);
        }
    }
}