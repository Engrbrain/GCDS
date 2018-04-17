using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class AMLCertification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string CertificateName { get; set; }
        public string Signature  { get; set; }
    public DateTime CertificationDate { get; set; }
    public string NameOfApplicant { get; set; }
    public string PositionToBeHeld { get; set; }
public DateTime TimeStamp { get; set; }
public bool Is_Deleted { get; set; }

    }
}