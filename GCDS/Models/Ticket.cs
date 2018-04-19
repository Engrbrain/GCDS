using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int TicketNumber { get; set; }
        public DateTime DateRaised { get; set; }
        public string Subject { get; set; }
        public enumManager.TicketStatus TicketStatus { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }

        public ICollection<TicketMessage> TicketMessage { get; set; }

    }
}