using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PaymentLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int PaymentHeaderId { get; set; }
        public virtual PaymentHeader PaymentHeader { get; set; }
        public int PaymentDate { get; set; }
        public int PaymentOption { get; set; }
        public int AmountPaid  { get; set; }
    public string PaymentReference { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }
    public int TotalPercentagePaid { get; set; }


}
}