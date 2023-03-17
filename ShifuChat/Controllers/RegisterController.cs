using System;
using Microsoft.AspNetCore.Mvc;
using ShifuChat.ViewModels;
using ShifuChat.BL;
using ShifuChat.DAL.Models;

namespace ShifuChat.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IIdentityUser _identity;

		public RegisterController(IIdentityUser identityUser)
		{
			_identity = identityUser;
		}

		[HttpGet]
		[Route("/Register")]
		public IActionResult Index()
		{
			return View("Index", new RegisterViewModel());
		}

		
		[HttpPost]
		[Route("/Register")]
		public async Task<IActionResult> IndexPost(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _identity.Create(
				ShifuChat.DAL.MapperIdentityUser.MapperUserIdenty.
				ReturnUserModelMapper(model));

				 return Redirect("/Home/Index");
			}

               return View("Index", model);
        }

    }
}

