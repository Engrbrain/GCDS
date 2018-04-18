﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class OffCourtCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LitigationReference { get; set; }
        public string CaseTitle { get; set; }
        public string CaseDescription { get; set; }
        public int? CompanyID { get; set; }
        public string LitigationDate { get; set; }
        public enumManager.LitigationStatus LitigationStatus { get; set; }

    }
}