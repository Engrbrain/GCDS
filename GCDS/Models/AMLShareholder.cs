using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class AMLShareholder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string NameOfShareholder { get; set; }
        public string Address { get; set; }
        public string Shareholding { get; set; }
        public int Percentage { get; set; }
        public Datetime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public int NumberOfShareholdersWithLessThanFivePercent { get; set; }

    }
}