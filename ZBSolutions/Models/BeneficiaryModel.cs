using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZBSolutions.Models
{
    public class BeneficiaryModel
    {

        //Beneficiary Information
        public string Nickname { get; set; }
        [Required] public int BeneficiaryId { get; set; }
        public int UserId { get; set; }


    }
}