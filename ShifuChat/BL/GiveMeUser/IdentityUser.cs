using System;
using ShifuChat.DAL;
using ShifuChat.DAL.Models;
using ShifuChat.BL.CryptoPub;
using ShifuChat.ViewModels;
using ShifuChat.BL.Helper;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ShifuChat.BL
{
    public class IdentityUser : IIdentityUser
    {
        private readonly IHttpContextAccessor _httpContex;
        private readonly IIdentityDbContext _identityDbContext;
        private readonly ICryptoWorker _crypto;

        public IdentityUser(IHttpContextAccessor httpContext, IIdentityDbContext identity,ICryptoWorker crypto)
        {
            _httpContex = httpContext;
            _identityDbContext = identity;
            _crypto = crypto;
        }


        public async Task<int> Create(UserModel model)
        {
           model.Salt = Guid.NewGuid().ToString();
           model.Password = _crypto.HashPassword(model.Password, model.Salt);

           int id =  await _identityDbContext.CreateUser(model);
           IsLogIn(id);
              return id;
        }

        public async Task<int> LoginUser(string email,string password,bool rememberMe)
        {
            var user = await _identityDbContext.GetUser(email);
            if (user.Id != null && user.Password == _crypto.HashPassword(password, user.Salt))
            {
                IsLogIn(user.Id ?? 0);
                return user.Id ?? 0;
            }
            else
                throw new Exception("not founde your email");
        }

        public void IsLogIn(int id)
        {
            _httpContex.HttpContext?.Session.SetInt32(Helper.ConstantSessionBL.constSession,id);
        }

        public async Task<ValidationResult?> ValidateUser(string email)
        {
            var user = await _identityDbContext.GetUser(email);
            if (user.Id != null)
                return new ValidationResult("Input uniq email adress");
            else
                return null;
        }

        public async void GetCryptoImage(string imageFile)
        {
            var image = imageFile;///imageFileName for path save file

            MD5 md5Hash = MD5.Create();
            byte[] input = Encoding.ASCII.GetBytes(Convert.ToString(image));///maybe on next step this variable 
            byte[] hashByte = md5Hash.ComputeHash(input);

            string hash = Convert.ToHexString(hashByte);

            var dirPath = ". /wwwroot/images/" +
                    hash.Substring(0, 2) + "/" +
                    hash.Substring(0, 4);

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            string fileName = dirPath + "/" + image;
            using (var stream = System.IO.File.Create(fileName))
            {
                await image.CopyToA(stream);
            }
        }
    }
}

