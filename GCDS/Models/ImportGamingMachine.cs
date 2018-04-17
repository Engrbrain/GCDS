﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class ImportGamingMachine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GamingEquipmentID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string FullNameOfApplicant { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string MakeOfMachine { get; set; }
        public int SerialNumber { get; set; }
        public string CountryOfOrigin { get; set; }
        public int CostOfMachine { get; set; }
        public bool Is_MachineImportForResale { get; set; }
        public string NameOfProposedPremisesForMachine { get; set; }
        public string ProposedTown_CityForMachine { get; set; }
        public string NameOfPresentPremisesForMAchine { get; set; }
        public string PresentTown_CityForMachine { get; set; }
        public int NumberOfPresentGamblingMachinesLicense { get; set; }
        public bool Is_TrueOwnerOfMachine { get; set; }
        public DateTime DateOfExpiryOfPresentLicense { get; set; }
        public string Signature  { get; set; }
    public DateTime ImportationDate { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }

}
}