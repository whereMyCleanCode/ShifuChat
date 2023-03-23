using System;
using ShifuChat.DAL;
using ShifuChat.DAL.Models;
using ShifuChat.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ShifuChat.BL
{
	public interface IIdentityUser
	{
		public Task<int> Create(UserModel model);
		public Task<int> LoginUser(string email,string password,bool rememberMe);
		public Task<ValidationResult> ValidateUser(string email); 
		////..........validation and more;
	}
}

