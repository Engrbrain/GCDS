using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class AMLHoldingCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string NameOfCompany { get; set; }
        public string RegistrationNumber { get; set; }
        public string PlaceOfIncorporation { get; set; }
        public string NatureOfBusiness { get; set; }
        public string RelationshipToCompany { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public int PercentageHolding { get; set; }

    }
}