using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class JournalHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string JournalNumber { get; set; }
        public journaltype JournalType { get; set; }
        public string JournalText { get; set; }
        public DateTime JournalDate { get; set; }
        public string SourceDocumentReference { get; set; }
        public int Period { get; set; }
        public int FiscalYear { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedComment { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedComment { get; set; }

    }
}