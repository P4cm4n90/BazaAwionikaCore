using System;
using System.Collections.Generic;
using System.Linq;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Model;

namespace BazaAwionika.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUser(int id);
        void CreateUser(UserModel user);
        void SaveUser();
        void DeleteUser(UserModel user);
        void UpdateUser(UserModel user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(UserModel user)
        {
            userRepository.Add(user);
        }

        public UserModel GetUser(int id)
        {
            return userRepository.GetById(id);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return userRepository.GetAll();
        }

        public void UpdateUser(UserModel user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(UserModel user)
        {
            userRepository.Delete(user);
        }


        public void SaveUser()
        {
            unitOfWork.Commit();
        }



        #region Overwrite

        #endregion
    }
}