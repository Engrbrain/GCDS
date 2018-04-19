using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class MinorMinorAccountCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MajorAccountCodeId { get; set; }
        public virtual MajorAccountCode MajorAccountCode { get; set; }
        public int MinorAccountCodeId { get; set; }
        public virtual MinorAccountCode MinorAccountCode { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string CompleteCOA { get; set; }
        public enumManager.accountType AccountType { get; set; }
        public double Is_Deleted { get; set; }

    }
}