using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFSecurityClearance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int PNFPersonalDetailsId { get; set; }
        public virtual PNFPersonalDetails PNFPersonalDetails { get; set; }
        public bool Is_LawOffender { get; set; }
        public string OffenseDescription { get; set; }
        public string Comments_AdditionalInformation { get; set; }
        public DateTime Date { get; set; }
        public bool Is_Declared { get; set; }
        public string Signature  { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }


}
}