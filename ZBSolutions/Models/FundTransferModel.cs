using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZBSolutions.Models
{
    public class FundTransferModel
    {
 
        //Fund transfer
        public long Balance { get; set; }

        [Required]
        public double Fund { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string TransferPassword { get; set; }

        [Required]
        public int Loginid2 { get; set; }

    }
}