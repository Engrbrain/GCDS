using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class AMLCompanyProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PreviousName { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string FacsimileNumber { get; set; }
        public string DateOfIncorporationOfCompany { get; set; }
        public string PlaceOfIncorporationOfCompany { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string CompanyRegistrationNumber { get; set; }

        public ICollection<AMLAgreement> AMLAgreement { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLAttachments> AMLAttachments { get; set; }
        public ICollection<AMLCertification> AMLCertification { get; set; }
        public ICollection<AMLCivilAction> AMLCivilAction { get; set; }
        public ICollection<AMLCompanyLawyer> AMLCompanyLawyer { get; set; }
        public ICollection<AMLConviction> AMLConviction { get; set; }
        public ICollection<AMLHoldingCompany> AMLHoldingCompany { get; set; }
        public ICollection<AMLLenders> AMLLenders { get; set; }

        public ICollection<AML> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }
        public ICollection<AMLBankAccount> AMLBankAccount { get; set; }


    }
}