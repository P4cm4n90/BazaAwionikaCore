using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface IOxygenExchangeService
    {
        IEnumerable<OxygenExchangeModel> GetOxygenExchanges();
        OxygenExchangeModel GetOxygenExchange(int id);
        void CreateOxygenExchange(OxygenExchangeModel oxygenExchange);
        void SaveOxygenExchange();

        void DeleteOxygenExchange(OxygenExchangeModel oxygenExchangeModel);


    }
    public class OxygenExchangeService : IOxygenExchangeService
    {
        private readonly IOxygenExchangeRepository oxygenExchangeRepository;
        private readonly IUnitOfWork unitOfWork;

        public OxygenExchangeService(IOxygenExchangeRepository oxygenExchangeRepository, IUnitOfWork unitOfWork)
        {
            this.oxygenExchangeRepository = oxygenExchangeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateOxygenExchange(OxygenExchangeModel oxygenExchange)
        {
            oxygenExchangeRepository.Add(oxygenExchange);
        }

        public OxygenExchangeModel GetOxygenExchange(int id)
        {
            return oxygenExchangeRepository.GetById(id);
        }

        public IEnumerable<OxygenExchangeModel> GetOxygenExchanges()
        {
            return oxygenExchangeRepository.GetAll();
        }

        public void SaveOxygenExchange()
        {
            unitOfWork.Commit();
        }

        public void DeleteOxygenExchange(OxygenExchangeModel oxygenExchangeModel)
        {
            oxygenExchangeRepository.Delete(oxygenExchangeModel);
        }
    }
}