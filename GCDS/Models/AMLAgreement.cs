using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace GCDS.Models
{
    public class AMLAgreement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string OwnershipDescription { get; set; }
        public string OperationDescription { get; set; }
        public string DevelopmentDescription { get; set; }
        public string FacilitationDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string RightOrInterestDescription { get; set; }

    }
}