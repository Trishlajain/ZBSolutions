using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_Library
{
    public class SignUpBal
    {
        //Personal Information
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
    }
}
