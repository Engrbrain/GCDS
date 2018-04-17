using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class InspectionTeamMembers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string InspectionTeamID { get; set; }
        public virtual InspectionTeam InspectionTeam { get; set; }
        public int InspectionOfficerID { get; set; }
        public virtual InspectionOfficer InspectionOfficer { get; set; }
        public DateTime DateAdded { get; set; }
        public string Is_Deleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public ICollection<InspectionRequest> InspectionRequest { get; set; }

    }
}