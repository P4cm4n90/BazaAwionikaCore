using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{

    public interface ISettingsService
    {
        IEnumerable<SettingsModel> GetSettings();
        SettingsModel GetSettings(int id);
        void CreateSettings(SettingsModel settings);

        void DeleteSettings(SettingsModel settings);
        void SaveSettings();


    }
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository settingsRepository;
        private readonly IUnitOfWork unitOfWork;

        public SettingsService(ISettingsRepository settingsRepository, IUnitOfWork unitOfWork)
        {
            this.settingsRepository = settingsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateSettings(SettingsModel settings)
        {
            settingsRepository.Add(settings);
        }

        public void DeleteSettings(SettingsModel settings)
        {
            settingsRepository.Delete(settings);
        }

        public SettingsModel GetSettings(int id)
        {
            return settingsRepository.GetById(id);
        }

        public IEnumerable<SettingsModel> GetSettings()
        {
            return settingsRepository.GetAll();
        }

        public void SaveSettings()
        {
            unitOfWork.Commit();
        }




    }
}