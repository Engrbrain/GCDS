using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class OffCourtCaseReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OffCourtCaseId { get; set; }
        public virtual OffCourtCase OffCourtCase { get; set;}
        public string ReportTitle { get; set; }
        public DateTime ReportDate { get; set; }
        public int UserID { get; set; }
        public string ReportAttachment { get; set; }
        public string ReportDetails { get; set; }

    }
}