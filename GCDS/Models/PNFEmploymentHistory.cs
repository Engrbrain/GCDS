using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFEmploymentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public int PNFPersonalDetailsID { get; set; }
        public string OrganisationFullName { get; set; }
        public bool Is_Apprenticeship { get; set; }
        public bool Is_SelfEmployment { get; set; }
        public bool Is_UnEmployment { get; set; }
        public bool Is_NationalService { get; set; }
        public string AddressOFOrganisation { get; set; }
        public int TelephoneNumberOfOrganisation { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime EmploymentEndDate { get; set; }
        public string Post { get; set; }
        public string DutiesDescription { get; set; }
        public bool Is_SecurityService_Employee { get; set; }
        public string BranchOfService_Unit { get; set; }
        public string Rank_Position { get; set; }
        public int ServiceNumber { get; set; }
        public DateTime DateOfEnlistment { get; set; }
        public string PlaceOfEnlistment { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string ReasonsForLeaving { get; set; }


    }
}