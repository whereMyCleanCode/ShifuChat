using System;
using System.ComponentModel.DataAnnotations;

namespace ShifuChat.ViewModels;

public class LoginViewModel
{
	[Key]
	[Required]
	[DataType(DataType.EmailAddress)]
	public string? Email { get; set; }

	[Key]
	[Required]
	[DataType(DataType.Password)]
	public  string? Password { get; set; }
	
	public  bool? RememberMe { get; set; }

 
}

