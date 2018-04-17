using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class TicketMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public int TicketID { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public DateTime MessageDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ResponseBy { get; set; }
        public string MessageBy { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }

    }
}