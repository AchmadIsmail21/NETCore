using ImplementCors.Base.Controllers;
using ImplementCors.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    public class LoginController : BaseController<Account, LoginRepository, string>
    {
        LoginRepository loginRepository;

        public LoginController(LoginRepository loginRepository) : base(loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Auth/")]
        public async Task<IActionResult> Auth(string email, string password) {
            LoginVM loginVM = new LoginVM();
            loginVM.Email = email;
            loginVM.Password = password;
            var jwtToken = await loginRepository.Auth(loginVM);
            var token = jwtToken.Token;

            if (token == null) {
                return RedirectToAction("login", "Login");
            }
            HttpContext.Session.SetString("JWToken", token);
            return RedirectToAction("Index", "home");
        }

    }
}
