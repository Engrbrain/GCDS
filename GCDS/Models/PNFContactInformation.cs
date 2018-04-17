using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class PNFContactInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public int PNFPersonalDetailsID { get; set; }
        public string CurrentResidentialAddress { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string PopularSpotsOrPersonalityNearResidence { get; set; }
        public string HomeNumber { get; set; }
        public int MobileNumber { get; set; }
        public int FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string PreviousResidenceAddress { get; set; }
        public string PreviousHouseNumber { get; set; }
        public string PreviousStreet { get; set; }
        public string PreviousTown { get; set; }
        public string PreviousDistrict { get; set; }
        public string PreviousRegion { get; set; }
        public string HomeTownAddress { get; set; }
        public string HomeTownHouseNumber { get; set; }
        public string HomeTownStreet { get; set; }
        public string HomeTownName { get; set; }
        public string HomeTownDistrict { get; set; }
        public string HomeTownRegion { get; set; }
        public string EmploymentAddress { get; set; }
        public string BusinessName { get; set; }
        public string BusinessStreetName { get; set; }
        public string BusinessTown { get; set; }
        public string BusinessState { get; set; }
        public string BusinessRegion { get; set; }
        public string AnyClosePopularSpotToBusiness { get; set; }
        public int EmployersTelephoneNumber  { get; set; }
public int EmployersFaxNumber  { get; set; }
public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string EmployesEmailAddress  { get; set; }

    }
}