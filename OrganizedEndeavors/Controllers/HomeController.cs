using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using OrganizedEndeavors.Data;
using OrganizedEndeavors.Models;

namespace OrganizedEndeavors.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var repo = new MembersRepository(Properties.Settings.Default.ConStr);
            var member = repo.GetByEmail(User.Identity.Name);
            return View(new IndexViewModel { MemberId = member.Id });
        }

        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var repo = new MembersRepository(Properties.Settings.Default.ConStr);
            var member = repo.LogIn(email, password);
            if (member == null)
            {
                return RedirectToAction("Login");
            }

            FormsAuthentication.SetAuthCookie(member.Email, false);
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member, string password)
        {
            var repo = new MembersRepository(Properties.Settings.Default.ConStr);
            repo.SignUp(member, password);
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}