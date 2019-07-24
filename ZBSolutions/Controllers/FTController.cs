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
    public class FTController : Controller
    {
        // GET: FT
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FundTransferAction()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FundTransferAction(FundTransferModel ft )
        {
            FundTransferBal bal = new FundTransferBal();
            bal.Fund = ft.Fund;
            bal.Loginid2 = ft.Loginid2;
            bal.UserId = Convert.ToInt32(Session["loginid"]);

            return View();
        }
    }
}
}