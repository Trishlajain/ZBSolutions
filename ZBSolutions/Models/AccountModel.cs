using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZBSolutions.Models
{
    public class AccountModel
    {
        //Account Information 
        public long AccountNo { get; set; }
        public string IfscCode { get; set; }
        public int UserId { get; set; }
    }
}