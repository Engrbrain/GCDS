using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class License
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateWithdrawn { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime ReviewedBy { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string IssuedBy { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string WithdrawnBy { get; set; }


    }
}