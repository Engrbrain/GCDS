using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class CourtCaseJudgement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CourtCaseId { get; set; }
        public string JudgementTitle { get; set; }
        public string JudgementDetails { get; set; }
        public string Attachment { get; set; }
        public DateTime JudgementDate { get; set; }

    }
}