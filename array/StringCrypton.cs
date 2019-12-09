using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace array
{
    public  static class StringCryptOgrapgy
    {
        
        public static void Cryptograyphy(out byte[] passwordHash, out byte[] key, string password)
        {
            using (var hmc = new System.Security.Cryptography.HMACSHA512())
            {
                key = hmc.Key;
                passwordHash = hmc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
               
        }


        public static bool GetPassword(string password, byte[] passwordHash, byte[] key)
        {
            using (var hmc = new System.Security.Cryptography.HMACSHA512(key) )
            {
                var computedHash = hmc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                if (computedHash.Where((t, i) => t != passwordHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
