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
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string NameOfLawyerOrLegalAdvisor { get; set; }
        public string AddressOfLawyerOrLegalAdvisor { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public enumManager.ProfessionalType ProfessionalType { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }

    }
}