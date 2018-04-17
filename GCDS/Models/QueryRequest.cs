using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class QueryRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string Reference { get; set; }
        public string QueryTitle { get; set; }
        public string QueryDescription { get; set; }
        //public QueryCategory QueryCategory { get; set; }
        public string ResponseTitle { get; set; }
        public string ResponseDate { get; set; }
        public string Response { get; set; }
        public string L1ReviewComment { get; set; }
        //public ReviewStatus L1ReviewStatus { get; set; }
        public string L1ReviewedBy { get; set; }
        public DateTime L1ReviewedOn { get; set; }
        public string L2ReviewComment { get; set; }
       // public ReviewStatus L2ReviewStatus { get; set; }
        public string L2ReviewedBy { get; set; }
        public DateTime L2ReviewedOn { get; set; }
        //public ResolutionStatus FinalResolution { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        //public ResolutionStatus FinalResolutionStatus { get; set; }


    }
}