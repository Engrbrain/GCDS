using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class InspectionOfficer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string InspectionOfficerName { get; set; }
        public string InspectionReference { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public enumManager.country Country { get; set; }
        public string OfficeDesignation { get; set; }
        public bool Is_Active { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public enumManager.InspectionOfficerType InspectionOfficerType { get; set; }

        public ICollection<InspectionTeamMembers> InspectionTeamMembers { get; set; }



    }
}