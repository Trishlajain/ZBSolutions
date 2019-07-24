using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZBSolutions.Models;
using Bal_Library;
using Dal_Library;

namespace ZBSolutions.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

   
        [HttpGet]
        public ActionResult MyAccountAction(AccountModel account)
        {
            AccountBal bal = new AccountBal();
            bal.UserId = Convert.ToInt32(Session["loginid"]);
            //bal.AccountNo = account.AccountNo;
            //bal.IfscCode = account.IfscCode;

            AccountDal dal = new AccountDal();
            bool status = dal.MyAccount(bal,out string IFSC,out int Acno);
 AccountModel model = new AccountModel();
            if (status)
            {
                //bal.AccountNo = account.AccountNo;
                //bal.IfscCode = account.IfscCode;              
                model.AccountNo = Acno;
                model.IfscCode = IFSC;
                model.UserId = bal.UserId;
            }
           
                return View(model);
            
            
        }

        [HttpGet]
        public ActionResult BenAction()
        {
            BeneficiaryBal bal = new BeneficiaryBal();
            bal.UserId = Convert.ToInt32(Session["loginid"]);
          

            BenDal dal = new BenDal();
            bool status = dal.ShowBen(bal, out string Nick, out int Bid);
            BeneficiaryModel model = new BeneficiaryModel();
            if (status)
            {
                           
                model.BeneficiaryId = Bid;
                model.Nickname = Nick;
                model.UserId = bal.UserId;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddBen()
        {          
                return View();
        }

        [HttpPost]
        public ActionResult AddBen(BeneficiaryModel ben)
        {

            BeneficiaryBal bal = new BeneficiaryBal();

            //Session passing
            bal.UserId = Convert.ToInt32(Session["loginid"]);

            bal.BeneficiaryId = ben.BeneficiaryId;
            bal.Nickname = ben.Nickname;

            BenDal dal = new BenDal();
            bool status = dal.benDetails(bal);

            if (status)
            {
                return RedirectToAction("BenAction");
            }
            else
            {
                return View();
            }
            
        }
    }
}