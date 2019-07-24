using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal_Library;
using Bal_Library;
using ZBSolutions.Models;

namespace ZBSolutions.Controllers
{
    public class LoginMainController : Controller
    {
        // GET: LoginMain
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MainLogin(LoginModel login)
        {
            LoginBal bdata = new LoginBal();
            bdata.UserId = login.UserId;
            bdata.Password = login.Password;

            ValidateMainDAL ddata = new ValidateMainDAL();
            bool status = ddata.ValidateMainLogin(bdata);

            //session sending login id to every page.....
            Session["loginid"] = bdata.UserId;

            if (status)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                return View();
            }
        }
    }
}