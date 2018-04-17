using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class AccountPayable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int EmailAddress { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string VendorFullName { get; set; }
        public bool VendorAddress { get; set; }
        public DateTime VendorGender { get; set; }
        public bool VendorEmailAddress { get; set; }
        public string ServiceDescription  { get; set; }


}
}