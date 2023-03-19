using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShifuChat.Models;
using ShifuChat.ViewModels;
using ShifuChat.BL.GiveMeUser;
using ShifuChat.BL;

namespace ShifuChat.Controllers
{
	public class LoginController : Controller 
	{

        private readonly IIdentityUser _identity;

        public LoginController(IIdentityUser identityUser)
        {
            _identity = identityUser;
        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Index()
        {
            return View("Index", new RegisterViewModel());
        }


        [HttpPost]
        [Route("/Login")]
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

