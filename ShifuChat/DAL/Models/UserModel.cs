using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShifuChat.DAL.Models
{
	public class UserModel
	{
		[Key]
		public int? Id { get; set; }
		public string Firstname { get; set; } = null!;
		public string SecondName { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Profession { get; set; } = null!;
		public string Salt { get; set; } = null!;
 		public string Password { get; set; } = null!;
	}
}
   

