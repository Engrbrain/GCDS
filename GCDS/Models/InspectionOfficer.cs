using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class InspectionOfficer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string InspectionOfficerName { get; set; }
        public string InspectionReference { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string OfficeDesignation { get; set; }
        public bool Is_Active { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }



    }
}