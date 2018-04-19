using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class TicketMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
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