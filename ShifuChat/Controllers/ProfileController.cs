using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShifuChat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ShifuChat.BL;
using ShifuChat.BL.CryptoPub;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShifuChat.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICryptoWorker _cryptoWorker;

        [HttpGet]
        [Route("/Profile")]
        public IActionResult Index()
        {
            return View("Index", new ProfileViewModel());
        }


        [HttpPost]
        [Route("/Profile")]
        public async Task<IActionResult> IndexPost()
        {
            //if (ModelState) valid methood on next step.Maybee add Antivirus image programm on background
            var imageFile = Request.Form.Files[0];//image Searce Enumerator Post Request methood in user form on next step
            string fileName = imageFile.FileName;
            if(imageFile != null)
            {
                 using (var stream = System.IO.File.Create(_cryptoWorker.GetCryptoImage(fileName)))
                {
                  await imageFile.CopyToAsync(stream);
                }
                 return View("Index", new ProfileViewModel());
            }
            return Redirect("/Home");
        }
    }
}

