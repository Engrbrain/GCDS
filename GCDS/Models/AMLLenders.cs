using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class AMLLenders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Account_RefNumber  { get; set; }
    public string TypeOfFacility { get; set; }
    public int AmountOfFacility { get; set; }
    public int RepaymentPeriod { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }
    public string RepaymentTerms { get; set; }

}
}