using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ShifuChat.BL.CryptoPub
{
    public class CryptoWorker : ICryptoWorker
    {
        public string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(password,
                System.Text.Encoding.ASCII.GetBytes(salt),
                KeyDerivationPrf.HMACSHA512,
                5000,64)
                );
        }
    }
}

