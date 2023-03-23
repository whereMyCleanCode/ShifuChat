using System;
using ShifuChat.DAL;
using ShifuChat.DAL.Models;
using ShifuChat.BL.CryptoPub;
using ShifuChat.ViewModels;
using ShifuChat.BL.Helper;
using System.ComponentModel.DataAnnotations;

namespace ShifuChat.BL
{
    public class IdentityUser : IIdentityUser
    {
        private readonly IHttpContextAccessor _httpContex;
        private readonly IIdentity _identityDbContext;
        private readonly ICryptoWorker _crypto;

        public IdentityUser(IHttpContextAccessor httpContext, IIdentity identity,ICryptoWorker crypto)
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
                return 0;
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

    }
}

