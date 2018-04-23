using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace GCDS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public enumManager.region State { get; set; }
        public enumManager.country Nationality { get; set; }
        public enumManager.Gender Gender { get; set; }
        public string UserSummary { get; set; }
        public string AboutUser { get; set; }
        public string JobDesignation { get; set; }
        public byte[] UserImage { get; set; }
        public enumManager.Scope scope { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TimeStamp { get; set; }

        public ApplicationUser()
        {
            TimeStamp = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<AccountPayable> AccountPayable { get; set; }
        public DbSet<AMLAgreement> AMLAgreement { get; set; }
        public DbSet<AMLAttachments> AMLAttachments { get; set; }
        public DbSet<AMLBankAccount> AMLBankAccount { get; set; }
        public DbSet<AMLCertification> AMLCertification { get; set; }
        public DbSet<AMLCivilAction> AMLCivilAction { get; set; }
        public DbSet<AMLCompanyLawyer> AMLCompanyLawyer { get; set; }
        public DbSet<AMLCompanyProfile> AMLCompanyProfile { get; set; }
        public DbSet<AMLConviction> AMLConviction { get; set; }
        public DbSet<AMLHoldingCompany> AMLHoldingCompany { get; set; }
        public DbSet<AMLLenders> AMLLenders { get; set; }
        public DbSet<AMLPendingCivilAction> AMLPendingCivilAction { get; set; }
        public DbSet<AMLPendingProsecution> AMLPendingProsecution { get; set; }
        public DbSet<AMLShareholder> AMLShareholder { get; set; }
        public DbSet<AMLSubsidiaryAssociate> AMLSubsidiaryAssociate { get; set; }
        public DbSet<AMLVestedInterest> AMLVestedInterest { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccount { get; set; }
        public DbSet<ComplianceTeam> ComplianceTeam { get; set; }
        public DbSet<ConsentToSellGamingMachines> ConsentToSellGamingMachines { get; set; }
        public DbSet<CourtCase> CourtCase { get; set; }
        public DbSet<CourtCaseJudgement> CourtCaseJudgement { get; set; }
        public DbSet<CourtCaseReport> CourtCaseReport { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public DbSet<ExpenseHeader> ExpenseHeader { get; set; }
        public DbSet<ExpenseLine> ExpenseLine { get; set; }
        public DbSet<GamingEquipment> GamingEquipment { get; set; }
        public DbSet<ImportGamingMachine> ImportGamingMachine { get; set; }
        public DbSet<InspectionOfficer> InspectionOfficer { get; set; }
        public DbSet<InspectionReport> InspectionReport { get; set; }
        public DbSet<InspectionReportCategory> InspectionReportCategory { get; set; }
        public DbSet<InspectionRequest> InspectionRequest { get; set; }
        public DbSet<InspectionTeam> InspectionTeam { get; set; }
        public DbSet<InspectionTeamMembers> InspectionTeamMembers { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeader { get; set; }
        public DbSet<InvoiceLine> InvoiceLine { get; set; }
        public DbSet<JournalHeader> JournalHeader { get; set; }
        public DbSet<JournalLine> JournalLine { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<LicenseOperateGamingMachine> LicenseOperateGamingMachine { get; set; }
        public DbSet<MajorAccountCode> MajorAccountCode { get; set; }
        public DbSet<Memo> Memo { get; set; }
        public DbSet<MinorAccountCode> MinorAccountCode { get; set; }
        public DbSet<MinorMinorAccountCode> MinorMinorAccountCode { get; set; }
        public DbSet<OffCourtCase> OffCourtCase { get; set; }
        public DbSet<OffCourtCaseReport> OffCourtCaseReport { get; set; }
        public DbSet<OffCourtJudgement> OffCourtJudgement { get; set; }
        public DbSet<Outlet> Outlet { get; set; }
        public DbSet<PaymentHeader> PaymentHeader { get; set; }
        public DbSet<PaymentLine> PaymentLine { get; set; }
        public DbSet<PNFAttachment> PNFAttachment { get; set; }
        public DbSet<PNFCompanyProfile> PNFCompanyProfile { get; set; }
        public DbSet<PNFContactInformation> PNFContactInformation { get; set; }
        public DbSet<PNFEconomicStatus> PNFEconomicStatus { get; set; }
        public DbSet<PNFEducationHistory> PNFEducationHistory { get; set; }
        public DbSet<PNFEmploymentHistory> PNFEmploymentHistory { get; set; }
        public DbSet<PNFExamsTaken> PNFExamsTaken { get; set; }
        public DbSet<PNFInformalEducation> PNFInformalEducation { get; set; }
        public DbSet<PNFPersonalDetails> PNFPersonalDetails { get; set; }
        public DbSet<PNFReferees> PNFReferees { get; set; }
        public DbSet<PNFSecurityClearance> PNFSecurityClearance { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeader { get; set; }
        public DbSet<PurchaseLineItem> PurchaseLineItem { get; set; }
        public DbSet<QueryRequest> QueryRequest { get; set; }
        public DbSet<Solicitor> Solicitor { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketMessage> TicketMessage { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<ImportGamingMachine>()
          .HasRequired(d => d.GamingEquipment)
          .WithMany(w => w.ImportGamingMachine)
          .HasForeignKey(d => d.GamingEquipmentId)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentLine>()
       .HasRequired(d => d.PaymentHeader)
       .WithMany(w => w.PaymentLine)
       .HasForeignKey(d => d.PaymentHeaderId)
       .WillCascadeOnDelete(false);

            modelBuilder.Entity<LicenseOperateGamingMachine>()
      .HasRequired(d => d.GamingEquipment)
      .WithMany(w => w.LicenseOperateGamingMachine)
      .HasForeignKey(d => d.GamingEquipmentId)
      .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsentToSellGamingMachines>()
      .HasRequired(d => d.GamingEquipment)
      .WithMany(w => w.ConsentToSellGamingMachines)
      .HasForeignKey(d => d.GamingEquipmentId)
      .WillCascadeOnDelete(false);

            modelBuilder.Entity<PNFPersonalDetails>()
     .HasRequired(d => d.AMLCompanyProfile)
     .WithMany(w => w.PNFPersonalDetails)
     .HasForeignKey(d => d.AMLCompanyProfileId)
     .WillCascadeOnDelete(false);

            modelBuilder.Entity<MinorMinorAccountCode>()
    .HasRequired(d => d.MinorAccountCode)
    .WithMany(w => w.MinorMinorAccountCode)
    .HasForeignKey(d => d.MinorAccountCodeId)
    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }

        public System.Data.Entity.DbSet<GCDS.Models.LicenseOperateGamingMachineAttachment> ImportGamingMachineAttachments { get; set; }
    }
}