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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        // LOGIN ACTION

        [HttpGet]
        public ActionResult LoginAction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAction(LoginModel login)
        {

            LoginBal bdata = new LoginBal();
            bdata.UserId = login.UserId;
            bdata.Password = login.Password;

            LoginDal ddata = new LoginDal();
            bool status = ddata.Login(bdata);

            //session sending login id to every page.....
            Session["loginid"] = bdata.UserId;

            if (status)
            {
                return RedirectToAction("SignUp");
            }
            else
            {
                return View();
            }
        }
        //=======LOGIN ACTION END

        //======SIGNUP START======

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel signup)
        {
            SignUpBal bal = new SignUpBal();

            //Session passing
            bal.UserId = Convert.ToInt32(Session["loginid"]);

            bal.Fullname = signup.Fullname;
            bal.Address = signup.Address;
            bal.DateOfBirth = signup.DateOfBirth;
            bal.PhoneNumber = signup.PhoneNumber;
            bal.Password = signup.NewPassword;

            SignUpDal sgnup = new SignUpDal();
            bool status = sgnup.SignUp(bal);

            if (status)
            {
                return RedirectToAction("MainLogin","LoginMain");
            }
            else
            {
                return View();
            }
        }





    }
}