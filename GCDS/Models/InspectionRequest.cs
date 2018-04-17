using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class InspectionRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int InspectionTeamId { get; set; }
        public virtual InspectionTeam InspectionTeam { get; set; }
        public string InspectionReference { get; set; }
        public DateTime InspectionStartDate { get; set; }
        public DateTime InspectionEndDate { get; set; }
        public int InspectionCategoryID { get; set; }
        public string Justification { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsApproved { get; set; }
        public string ReviewComment { get; set; }
        public string ApprovalComment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ReviewedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ReviewedBy { get; set; }
        public string ApprovedBy { get; set; }
        public int InspectionOfficerID { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
    }
}
