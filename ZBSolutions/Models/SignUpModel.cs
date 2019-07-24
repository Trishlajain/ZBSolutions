using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZBSolutions.Models
{
    public class SignUpModel
    {
        //Personal Information
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

       

    }
}