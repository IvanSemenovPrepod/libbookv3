using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace libbook.Controllers
{
    public class AccountController : Controller
    {
        Services.Account m_account = new Services.Account();
        // GET: Student
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(datamodel.Account account, string returnUrl)
        {
            var user = m_account.GetAccountByLoginPassword(account.Login, account.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(account.Login, true);
                return RedirectToAction("Index", "LendingBook");
            }
            return View(account);
        }

        public ActionResult Index()
        {
            var account = m_account.GetAccountByLogin(User.Identity.Name);
            return View(account);
        }

        public ActionResult Edit(int id)
        {
            var account = m_account.GetAccountById(id);
            return View(account);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Edit(datamodel.vAccount account)
        {
            var result = m_account.EditUser(account);
            if(result)
                return RedirectToAction("Index");//всё норм
            return RedirectToAction("Index");//должна быть инфа об ошибке
        }
    }
}