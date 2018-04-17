using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class AMLCompanyLawyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string NameOfLawyerOrLegalAdvisor { get; set; }
        public string AddressOfLawyerOrLegalAdvisor { get; set; }
        public string NameOfAccountant { get; set; }
        public string AddressOfAccountant { get; set; }
        public string NameOfConsultant { get; set; }
        public string AddressOfConsultant { get; set; }
        public string NameOfAuditor { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string AddressOfAuditor { get; set; }

    }
}