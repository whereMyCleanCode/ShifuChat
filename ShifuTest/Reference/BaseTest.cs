using System;
using ShifuChat.BL;
using ShifuChat.DAL;
using Microsoft.AspNetCore.Http;
using ShifuChat.BL.CryptoPub;
using System.Net.Http;

namespace ShifuTest.Reference
{
	public class BaseTest
	{
        protected IHttpContextAccessor _httpContext = new HttpContextAccessor();
        protected IIdentityDbContext _identityDbContext = new IdentityDbContext();
        protected ICryptoWorker _crypto = new CryptoWorker();
        protected IIdentityUser _identityUser;

        public BaseTest()
        {
            _identityUser = new IdentityUser( _httpContext,  _identityDbContext,  _crypto);
        }
    }
}

