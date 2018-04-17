using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class AMLConviction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string NameOfConvictor { get; set; }
        public string DesignationOfConvictor { get; set; }
        public string CourtConvicted { get; set; }
        public DateTime DateOfConviction { get; set; }
        public string OffenceDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string PenaltyDescription { get; set; }

    }
}