using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace HomeFinance.Core.Helpers
{
    public static class CryptographyPasswordHelper
    {
        public static string Encrypt(string password)
        {
            return Crypto.HashPassword(password);
        }

        public static bool VerifyPassword(string hashedPassword,string password)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }
    }
}
