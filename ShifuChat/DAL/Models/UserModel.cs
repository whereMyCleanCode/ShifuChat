using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShifuChat.DAL.Models
{
	public class UserModel
	{
		[Key]
		public int? Id { get; set; }
        [Key]
        public string Firstname { get; set; } = null!;
        [Key]
        public string SecondName { get; set; } = null!;
        [Key]
        public string Phone { get; set; } = null!;
        [Key]
        public string Email { get; set; } = null!;
        [Key]
        public string Profession { get; set; } = null!;
        [Key]
        public string Salt { get; set; } = null!;
        [Key]
        public string Password { get; set; } = null!;
	}
}
   

