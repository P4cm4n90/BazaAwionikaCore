using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IOxygenCylinderPortableService
    {
        IEnumerable<OxygenCylinderPortableModel> GetOxygenCylinderPortables();
        OxygenCylinderPortableModel GetOxygenCylinderPortable(int id);
        void CreateOxygenCylinderPortable(OxygenCylinderPortableModel oxygenCylinderPortable);
        void SaveOxygenCylinderPortable();
        void DeleteOxygenCylinderPortable(OxygenCylinderPortableModel oxygenCylinderPortableModel);


    }
    public class OxygenCylinderPortableService : IOxygenCylinderPortableService
    {
        private readonly IOxygenCylinderPortableRepository oxygenCylinderPortableRepository;
        private readonly IUnitOfWork unitOfWork;

        public OxygenCylinderPortableService(IOxygenCylinderPortableRepository oxygenCylinderPortableRepository, IUnitOfWork unitOfWork)
        {
            this.oxygenCylinderPortableRepository = oxygenCylinderPortableRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateOxygenCylinderPortable(OxygenCylinderPortableModel oxygenCylinderPortable)
        {
            oxygenCylinderPortableRepository.Add(oxygenCylinderPortable);
        }

        public OxygenCylinderPortableModel GetOxygenCylinderPortable(int id)
        {
            return oxygenCylinderPortableRepository.GetById(id);
        }

        public IEnumerable<OxygenCylinderPortableModel> GetOxygenCylinderPortables()
        {
            return oxygenCylinderPortableRepository.GetAll();
        }

        public void SaveOxygenCylinderPortable()
        {
            unitOfWork.Commit();
        }

        public void DeleteOxygenCylinderPortable(OxygenCylinderPortableModel oxygenCylinderPortableModel)
        {
            oxygenCylinderPortableRepository.Delete(oxygenCylinderPortableModel);
        }
    }
}