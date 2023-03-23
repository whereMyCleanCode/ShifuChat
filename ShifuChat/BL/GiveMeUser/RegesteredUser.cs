using System;
using Microsoft.AspNetCore.Http;
using ShifuChat.BL.Helper;

namespace ShifuChat.BL.GiveMeUser
{
    public class RegesteredUser : IRegesteredUser
    {
        private readonly IHttpContextAccessor _httpContext;

        public RegesteredUser(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public bool IsRegesteredUser()
        {
            return _httpContext.HttpContext?.Session?.GetInt32(Helper.ConstantSessionBL.constSession) != null;
        }
    }
}

