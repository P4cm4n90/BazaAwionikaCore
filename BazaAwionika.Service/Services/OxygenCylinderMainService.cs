using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IOxygenCylinderMainService
    {
        IEnumerable<OxygenCylinderMainModel> GetOxygenCylindersMain();
        OxygenCylinderMainModel GetOxygenCylinderMain(int id);
        void CreateOxygenCylinderMain(OxygenCylinderMainModel oxygenCylinderMain);
        void SaveOxygenCylinderMain();
        void DeleteOxygenCylinderMain(OxygenCylinderMainModel oxygenCylinderMainModel);


    }
    public class OxygenCylinderMainService : IOxygenCylinderMainService
    {
        private readonly IOxygenCylinderMainRepository oxygenCylinderMainRepository;
        private readonly IUnitOfWork unitOfWork;

        public OxygenCylinderMainService(IOxygenCylinderMainRepository oxygenCylinderMainRepository, IUnitOfWork unitOfWork)
        {
            this.oxygenCylinderMainRepository = oxygenCylinderMainRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateOxygenCylinderMain(OxygenCylinderMainModel oxygenCylinderMain)
        {
            oxygenCylinderMainRepository.Add(oxygenCylinderMain);
        }

        public OxygenCylinderMainModel GetOxygenCylinderMain(int id)
        {
            return oxygenCylinderMainRepository.GetById(id);
        }

        public IEnumerable<OxygenCylinderMainModel> GetOxygenCylindersMain()
        {
            return oxygenCylinderMainRepository.GetAll();
        }

        public void SaveOxygenCylinderMain()
        {
            unitOfWork.Commit();
        }

        public void DeleteOxygenCylinderMain(OxygenCylinderMainModel oxygenCylinderMainModel)
        {
            oxygenCylinderMainRepository.Delete(oxygenCylinderMainModel);
        }
    }
}