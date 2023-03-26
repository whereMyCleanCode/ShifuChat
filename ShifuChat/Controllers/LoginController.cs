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
        private readonly IRegesteredUser _isRegestered;

        public LoginController(IIdentityUser identityUser,IRegesteredUser isRegestered)
        {
            _identity = identityUser;
            _isRegestered = isRegestered;
        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Index()
        {
            return View("Index", new LoginViewModel());
        }


        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> IndexPost(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _identity.LoginUser(model.Email!, model.Password!, model.RememberMe == true);
                    return Redirect("Home/Index");
                }
                catch(Exception xpn)
                {
                    ModelState.AddModelError("Email", "Email or Password is false");
                }
                    
            }

            return View("Index", model);
        }

    }
}

