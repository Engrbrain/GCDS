using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class AMLPendingProsecution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string NameOfAccused { get; set; }
        public string DesignationOfAccused { get; set; }
        public string ProsecutionDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string NameOfProsecutor { get; set; }

    }
}