﻿using System;
using ShifuChat.DAL.Models;
using Npgsql;

namespace ShifuChat.DAL
{
	public interface IIdentityDbContext
	{
        Task<int> CreateUser(UserModel model);
	    Task<UserModel> GetUser(int id);
        Task<UserModel> GetUser(string email);
    }
}

