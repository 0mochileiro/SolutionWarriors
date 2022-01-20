using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionWarriors.Engine.Entitys;
using SolutionWarriors.UI.Models;
using System;
using System.Security.Claims;

namespace SolutionWarriors.UI.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        public ActionResult Index()
        {
            //Check if the user is logged in and redirects to index;

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Manager");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountModel model)
        {
            if (string.IsNullOrEmpty(model.UserEmail) && string.IsNullOrEmpty(model.UserPassword))
                return BadRequest();

            try
            {
                var userAuthorized = new UserModel().VerifyUser(model);

                if (userAuthorized == UserAuthorized.Authorized)
                {
                    var credentials = new UserModel().GetCredentials(model.UserEmail);

                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, credentials.userNickname),
                    new Claim(ClaimTypes.Email, credentials.userEmail),
                    new Claim(ClaimTypes.Role, "Admin")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity); ;

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Manager");
                }

                else if (userAuthorized == UserAuthorized.Unauthorized)
                {
                    ViewBag.Login = "E-mail ou senha incorretos!";

                    return View();
                }

                else
                {
                    ViewBag.Login = "Usuário não encontrado!";

                    return View();
                }

            }
            catch (Exception ex)
            {
                // Add exception handling with logs;

                return BadRequest();
            }
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }
    }
}
