using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Security
    {
        public static string ComputeHash(string text)
        {
            SHA512 algorithm = SHA512.Create();
            byte[] result = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(result);
        }
    }
}
