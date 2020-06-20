using System;

namespace Common.Api.Helper
{
    public static class CommonHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmach = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmach.Key;
                passwordHash = hmach.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            //throw new NotImplementedException();
        }
        public static bool VerifyPasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {
            using (var hmach = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computerHash = hmach.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                {
                    if (computerHash[i] != passwordHash[i]) 
                        return false;
                }
            }
            return true;
        }

    }
}
