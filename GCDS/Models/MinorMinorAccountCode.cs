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
        public int MajorAccountCodeID { get; set; }
        public int MinorAccountCodeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string CompleteCOA { get; set; }
        public accountType AccountType { get; set; }
        public double Is_Deleted { get; set; }

    }
}