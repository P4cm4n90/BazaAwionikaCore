using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

namespace BazaAwionika.Data.Infrastructure
{
    
    public static class PasswordManager
    {
        private static string GenerateSalt() { return BCrypt.BCryptHelper.GenerateSalt(); }
        public static string HashPassword(string password)
        {
            var salt = GenerateSalt();
            return BCrypt.BCryptHelper.HashPassword(password, salt);
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.BCryptHelper.CheckPassword(password, hashedPassword);
        }


    }
}
