using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class AccountPayable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public enumManager.country Country { get; set; }
        public string Region { get; set; }
        public string VendorFullName { get; set; }
        public bool VendorAddress { get; set; }
        public DateTime VendorGender { get; set; }
        public bool VendorEmailAddress { get; set; }
        public string ServiceDescription  { get; set; }


}
}