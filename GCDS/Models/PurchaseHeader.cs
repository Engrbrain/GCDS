﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PurchaseHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountPayableId { get; set; }
        public virtual AccountPayable AccountPayable { get; set; }
        public string PurchaseReference { get; set; }
        public string PurchaseDate { get; set; }
        public int PurchaseHeaderText { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedComment { get; set; }
        public string ReviewDate { get; set; }
        public bool ApprovedBy { get; set; }
        public DateTime ApprovedComment { get; set; }
        public bool ApprovalDate { get; set; }

        public ICollection<PurchaseLineItem> PurchaseLineItem { get; set; }

    }
}