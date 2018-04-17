using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class JournalLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int JournalHeaderID { get; set; }
        public string JournalNumber { get; set; }
        public int LineItemNumber { get; set; }
        public string GLAccount { get; set; }
        public string Narration { get; set; }
        public double CreditAmount { get; set; }
        public double DebitAmount { get; set; }

    }
}