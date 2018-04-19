using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PurchaseLineItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PurchaseHeaderId { get; set; }
        public virtual PurchaseHeader PurchaseHeader { get; set; }
        public string LineItemNumber { get; set; }
        public string Narration { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double GrossPrice { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double NetPrice { get; set; }
        public bool Is_Delivered { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentReference { get; set; }

    
    }
}