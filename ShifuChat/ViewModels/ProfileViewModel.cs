using System;
using System.ComponentModel.DataAnnotations;

namespace ShifuChat.ViewModels
{
	public class ProfileViewModel
	{
		[Key]
		[Required]
		public string? ProfileId { get; set; }
        [Key]
        [Required]
        public string? ProfileImage { get; set; }
        [Key]
        [Required]
        public string? FirstName { get; set; }
        [Key]
        [Required]
        public string? SecondName { get; set; }

    }
}

