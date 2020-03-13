using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;

namespace BazaAwionika.Data.Repositories
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public UserModel GetUserByName(string name)
        {
            return GetAll().SingleOrDefault(c => c.Name.CompareTo(name) == 0);
        }

        #region overwritten methods

        public override void Add(UserModel entity)
        {
            entity.PasswordHash = PasswordManager.HashPassword(entity.Password);
            base.Add(entity);
        }


        public bool VerifyUser(UserModel entity)
        {
            var user = GetUserByName(entity.Name) ?? throw new KeyNotFoundException("Nie znaleziono użytkownika o takiej nazwie");
            return PasswordManager.VerifyPassword(user.PasswordHash, entity.Password);
        }



        #endregion
    }

    public interface IUserRepository : IRepository<UserModel>
    {
        UserModel GetUserByName(string name);

        bool VerifyUser(UserModel entity);

    }
}