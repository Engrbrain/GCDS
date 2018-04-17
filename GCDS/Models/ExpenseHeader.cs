using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class ExpenseHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public int CompanyID { get; set; }
        public string PaymentReference { get; set; }
        public DateTime DocumentDate { get; set; }
        public string HeaderText { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewComment { get; set; }
        public string ApprovedComment { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public enumManager.PaymentStatus Status { get; set; }

    }
}