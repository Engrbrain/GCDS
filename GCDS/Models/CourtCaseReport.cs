using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class CourtCaseReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CourtCaseId { get; set; }
        public virtual CourtCase CourtCase { get; set; }
        public string ReportTitle { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportAttachment { get; set; }
        public string ReportDetails { get; set; }

    }
}