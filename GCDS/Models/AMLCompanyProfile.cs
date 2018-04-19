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
        public ICollection<ConsentToSellGamingMachines> ConsentToSellGamingMachines { get; set; }
        public ICollection<CourtCase> CourtCase { get; set; }
        public ICollection<ExpenseHeader> ExpenseHeader { get; set; }
        public ICollection<GamingEquipment> GamingEquipment { get; set; }
        public ICollection<ImportGamingMachine> ImportGamingMachine { get; set; }
        public ICollection<InspectionRequest> InspectionRequest { get; set; }
        public ICollection<InvoiceHeader> InvoiceHeader { get; set; }
        public ICollection<JournalHeader> JournalHeader { get; set; }

        public ICollection<License> License { get; set; }

        public ICollection<LicenseOperateGamingMachine> LicenseOperateGamingMachine { get; set; }
        public ICollection<Memo> Memo { get; set; }
        public ICollection<OffCourtCase> OffCourtCase { get; set; }
        public ICollection<Outlet> Outlet { get; set; }
        public ICollection<PaymentHeader> PaymentHeader { get; set; }
        public ICollection<PNFAttachment> PNFAttachment { get; set; }
        public ICollection<PNFCompanyProfile> PNFCompanyProfile { get; set; }
        public ICollection<PNFContactInformation> PNFContactInformation { get; set; }
        public ICollection<PNFEconomicStatus> PNFEconomicStatus { get; set; }
        public ICollection<PNFEducationHistory> PNFEducationHistory { get; set; }
        public ICollection<PNFEmploymentHistory> PNFEmploymentHistory { get; set; }
        public ICollection<PNFInformalEducation> PNFInformalEducation { get; set; }
        public ICollection<PNFExamsTaken> PNFExamsTaken { get; set; }
        public ICollection<PNFPersonalDetails> PNFPersonalDetails { get; set; }
        public ICollection<PNFReferees> PNFReferees { get; set; }
        public ICollection<PNFSecurityClearance> PNFSecurityClearance { get; set; }
        public ICollection<PurchaseHeader> PurchaseHeader { get; set; }
        public ICollection<PurchaseLineItem> PurchaseLineItem { get; set; }
        public ICollection<QueryRequest> QueryRequest { get; set; }
        public ICollection<Solicitor> Solicitor { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
        public ICollection<TicketMessage> TicketMessage { get; set; }

    }
}