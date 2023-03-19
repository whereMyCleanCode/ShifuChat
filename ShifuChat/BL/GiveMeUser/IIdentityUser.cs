using System;
using ShifuChat.DAL;
using ShifuChat.DAL.Models;
using ShifuChat.ViewModels;

namespace ShifuChat.BL
{
	public interface IIdentityUser
	{
		public Task<int> Create(UserModel model);
		public Task<int> SearceUser(string email,string password);
		////..........validation and more;
	}
}

