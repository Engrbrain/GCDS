﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class InspectionTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public string Is_Deleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public ICollection<InspectionRequest> InspectionRequest { get; set; }
        public ICollection<InspectionTeamMembers> InspectionTeamMembers { get; set; }

    }
}