using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class AMLVestedInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public bool Is_Interest_InPerson { get; set; }
        public bool Is_Interest_InCompany { get; set; }
        public string InterestDescription { get; set; }
        public bool Is_Supporting_Company { get; set; }
        public bool Is_Supporting_Business { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string SupportDescription { get; set; }

    }
}