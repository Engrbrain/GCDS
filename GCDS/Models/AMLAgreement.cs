using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class AMLAgreement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string OwnershipDescription { get; set; }
        public string OperationDescription { get; set; }
        public string DevelopmentDescription { get; set; }
        public string FacilitationDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string RightOrInterestDescription { get; set; }

    }
}