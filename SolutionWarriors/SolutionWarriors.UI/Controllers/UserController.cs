using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionWarriors.UI.Models;

namespace SolutionWarriors.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            try
            {
                return View(new UserModel().GetUser());

            }
            catch
            {
                return View("Error");
            }

        }

        public ActionResult UserDetails(int id)
        {
            try
            {
                return View(new UserModel().GetUser(id));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(AccountModel user)
        {
            try
            {
                new UserModel().RegisterUser(user);

                return RedirectToAction("UserList");
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(AccountModel user)
        {
            try
            {
                new UserModel().UpdateUser(user);

                return RedirectToAction("UserList");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult DeleteUser(int id)
        {
            try
            {
                new UserModel().DeleteUser(id);

                return RedirectToAction("UserList");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
