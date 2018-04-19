using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class InspectionReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int InspectionRequestId { get; set; }
        public virtual InspectionRequest InspectionRequest { get; set; }
        public DateTime InspectionStartDate { get; set; }
        public DateTime InspectionEndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InspectionCategoryId { get; set; }
        public enumManager.InspectionStatus Status { get; set; }
        public string InspectionResult { get; set; }
        public DateTime ReviewedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ReviewedBy { get; set; }
        public string ApprovedBy { get; set; }
        public int InspectionOfficerId { get; set; }
        public bool IsDeleted { get; set; }
        public string ReviewComment { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string InspectionReportAttachment { get; set; }
        public string ApprovedComment { get; set; }

    }
}
