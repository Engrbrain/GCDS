﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class Solicitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string SolicitorFullName { get; set; }
        public string SolicitorAddress { get; set; }
        public string SolicitorEmailAddress { get; set; }


        public ICollection<CourtCase> CourtCase { get; set; }
    }
}