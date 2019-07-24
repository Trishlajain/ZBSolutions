using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZBSolutions.Models
{
    public class LoginModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       

        //Login Date Time
        public DateTime LoginDateTime { get; set; }


    }
}