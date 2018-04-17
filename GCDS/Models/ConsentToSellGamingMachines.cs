using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class ConsentToSellGamingMachines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GamingEquipmentID { get; set; }
        public virtual GamingEquipment GamingEquipment { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string FullNameOfApplicant { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string MakeOfMachine { get; set; }
        public int SerialNumber { get; set; }
        public string NatureOfProposedTransaction { get; set; }
        public string NatureOfProposedBuyer_Hirer_Consignee { get; set; }
        public string AddressOfProposedBuyer_Hirer_Consignee { get; set; }
        public string NationalityOfProposedBuyer_Hirer_Consignee { get; set; }
        public string NameOfProposedPremisesForMachine { get; set; }
        public string ProposedTown_CityForMachine { get; set; }
        public string NameOfPresentPremisesForMAchine { get; set; }
        public string PresentTown_CityForMachine { get; set; }
        public int NumberOfPresentGamblingMachinesLicense { get; set; }
        public bool Is_TrueOwnerOfMachine { get; set; }
        public DateTime DateOfExpiryOfPresentLicense { get; set; }
        public string SignatureOfApplicant  { get; set; }
    public DateTime ConsentDate { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }

}
}