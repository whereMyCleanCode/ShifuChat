using System;
namespace ShifuChat.ViewModels.Login
{
	public class LoginViewModel
	{
		string? Email { get; set; }

		string? Password { get; set; }

		bool RememberMe { get; set; } = false;
	}
}

