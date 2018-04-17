using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class InvoiceLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public int CompanyID { get; set; }
        public int PaymentCategoryID { get; set; }
        public int UserID { get; set; }
        public int InvoiceHeaderId { get; set; }
        public string LineitemNumber { get; set; }
        public string Narration { get; set; }
        public int PaymentCateroryID { get; set; }
        public int UnitPrice  { get; set; }
    public string Units { get; set; }
    public int GrossAmount { get; set; }
    public int Discount { get; set; }
    public int Tax { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }
    public int NetAmount { get; set; }


}
}