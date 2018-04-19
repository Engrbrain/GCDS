using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFCompanyProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int PNFPersonalDetailsId { get; set; }
        public virtual PNFPersonalDetails PNFPersonalDetails { get; set; }
        public string NameOfCompany { get; set; }
        public string BusinessAddressOfCompany { get; set; }
        public string HouseNumberOfCompany { get; set; }
        public string StreetNameOfCompany { get; set; }
        public string TownOfCompany { get; set; }
        public string PopularSpotCloseToCompany { get; set; }
        public DateTime DateOfIncorporation { get; set; }
        public int RegistrationNumber { get; set; }
        public int NumberOfInitialWorkForce { get; set; }
        public string NameOfBankers { get; set; }
        public string AddressOfBankers { get; set; }
        public string NameOfAuditors { get; set; }
        public string AddressOfAuditors { get; set; }
        public string NameOfOtherCompanyDirectors { get; set; }
        public string AddressofOtherCompanyDirectors { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string ReasonsForEstablishingCompany { get; set; }

    }
}