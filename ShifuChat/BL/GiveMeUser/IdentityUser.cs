﻿using System;
using ShifuChat.DAL;
using ShifuChat.DAL.Models;
using ShifuChat.BL.CryptoPub;
using ShifuChat.ViewModels.Login;

namespace ShifuChat.BL
{
    public class IdentityUser : IIdentityUser
    {
        private readonly IHttpContextAccessor _httpContex;
        private readonly IIdentity _identity;
        private readonly ICryptoWorker _crypto;

        public IdentityUser(IHttpContextAccessor httpContext, IIdentity identity,ICryptoWorker crypto)
        {
            _httpContex = httpContext;
            _identity = identity;
            _crypto = crypto;
        }


        public async Task<int> Create(UserModel model)
        {
           model.Salt = Guid.NewGuid().ToString();
           model.Password = _crypto.HashPassword(model.Password, model.Salt);

            return  await _identity.CreateUser(model);

        }

        public async Task<int> SearceUser(string email,string password)///bool remember me methood will be in next commit check it
        {
            var user = await _identity.GetUser(email);
            if (user.Id != null && password == _crypto.HashPassword(password, user.Salt))
            {
                return user.Id ?? 0;///-<await return id
            }
            return 0;
        }


        ////login methood with db session tommorow
    }
}
