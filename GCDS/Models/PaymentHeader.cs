using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PaymentHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int InvoiceNumber { get; set; }
        public int LineitemNumber { get; set; }
        public int AmountDue  { get; set; }
        public int AmountPaid  { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string PaymentType { get; set; }
        public int TotalPercentagePaid { get; set; }

        public ICollection<PaymentLine> PaymentLine { get; set; }
    }
}