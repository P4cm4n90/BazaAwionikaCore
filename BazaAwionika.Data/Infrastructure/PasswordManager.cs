using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BazaAwionika.Data.Infrastructure
{
    
    public static class PasswordManager
    {
        private static string GenerateSalt() { return BCrypt.Net.BCrypt.GenerateSalt(); }
        public static string HashPassword(string password)
        {
            var salt = GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


    }
}
