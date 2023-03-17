using System;
using ShifuChat.DAL.Models;
using ShifuChat.ViewModels;

namespace ShifuChat.DAL.MapperIdentityUser
{
	public class MapperUserIdenty
	{
		public static UserModel ReturnUserModelMapper(RegisterViewModel model)
		{
			return new UserModel()
			{
				Email = model.Email!,
				Password = model.Password!
			};
		}
	}
}

