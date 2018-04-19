using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFEconomicStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int PNFPersonalDetailsId { get; set; }
        public virtual PNFPersonalDetails PNFPersonalDetails { get; set; }
        public bool Is_AssetOwner { get; set; }
        public string AssetParticulars_Description { get; set; }
        public string LocationOfAsset { get; set; }
        public string DescriptionOfObtainingAsset { get; set; }
        public int TaxCertificateNumberOfAsset { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime IssueDateOfTaxCertificateOfAsset { get; set; }


    }
}