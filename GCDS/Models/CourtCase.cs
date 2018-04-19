using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class CourtCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SuitNumber { get; set; }
        public string SuitTitle { get; set; }
        public string SuitDescription { get; set; }
        public DateTime SuitDate { get; set; }
        public string SolicitorID { get; set; }
        public virtual Solicitor Solicitor { get; set; }
        public int? AMLCompanyProfileID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }

        public string CourtCaseStatus { get; set; }

        public ICollection<CourtCaseJudgement> CourtCaseJudgement { get; set; }
        public ICollection<CourtCaseReport> CourtCaseReport { get; set; }

    }
}