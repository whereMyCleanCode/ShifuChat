using System;
using System.Security.Cryptography;
using System.Text;
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

        public string GetCryptoImage(string imageFile)
        {
            string file = imageFile;///imageFileName for path save file

            MD5 md5Hash = MD5.Create();
            byte[] input = Encoding.ASCII.GetBytes(Convert.ToString(file));///maybe on next step this variable 
            byte[] hashByte = md5Hash.ComputeHash(input);

            string hash = Convert.ToHexString(hashByte);

            var dirPath = "./wwwroot/images/" +
                   hash.Substring(0, 2) + "/" +
                   hash.Substring(0, 4);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            string fileName = dirPath + "/" + file;
            return fileName; 

        }
    }
}

