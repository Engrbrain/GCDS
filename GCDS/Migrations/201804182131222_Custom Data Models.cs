namespace GCDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomDataModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountPayables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Country = c.Int(nullable: false),
                        Region = c.String(),
                        VendorFullName = c.String(),
                        VendorAddress = c.Boolean(nullable: false),
                        VendorGender = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        VendorEmailAddress = c.Boolean(nullable: false),
                        ServiceDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AMLAgreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        AMLCompanyProfileID = c.Int(nullable: false),
                        OwnershipDescription = c.String(),
                        OperationDescription = c.String(),
                        DevelopmentDescription = c.String(),
                        FacilitationDescription = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        RightOrInterestDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AMLCompanyProfileID);
            
            CreateTable(
                "dbo.AMLCompanyProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        PreviousName = c.String(),
                        PhysicalAddress = c.String(),
                        PostalAddress = c.String(),
                        TelephoneNumber = c.String(),
                        FacsimileNumber = c.String(),
                        DateOfIncorporationOfCompany = c.String(),
                        PlaceOfIncorporationOfCompany = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        CompanyRegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AMLAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileID = c.Int(nullable: false),
                        UserID = c.String(),
                        AttachmentCategory = c.Int(nullable: false),
                        ReferenceNumber = c.String(),
                        FilePath = c.String(),
                        FileName = c.String(),
                        UploadedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        DocumentType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileID, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileID);
            
            CreateTable(
                "dbo.AMLBankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfBank = c.String(),
                        AccountNumber = c.Int(nullable: false),
                        AccountName = c.String(),
                        Address = c.String(),
                        ContactNames = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        Is_ForeignAccount = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLCertifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        CertificateName = c.String(),
                        Signature = c.String(),
                        CertificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NameOfApplicant = c.String(),
                        PositionToBeHeld = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLCivilActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        CivilActionDescription = c.String(),
                        CivilActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        AmountOwed = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLCompanyLawyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfLawyerOrLegalAdvisor = c.String(),
                        AddressOfLawyerOrLegalAdvisor = c.String(),
                        NameOfAccountant = c.String(),
                        AddressOfAccountant = c.String(),
                        NameOfConsultant = c.String(),
                        AddressOfConsultant = c.String(),
                        NameOfAuditor = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        AddressOfAuditor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLConvictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfConvictor = c.String(),
                        DesignationOfConvictor = c.String(),
                        CourtConvicted = c.String(),
                        DateOfConviction = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OffenceDescription = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        PenaltyDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLHoldingCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfCompany = c.String(),
                        RegistrationNumber = c.String(),
                        PlaceOfIncorporation = c.String(),
                        NatureOfBusiness = c.String(),
                        RelationshipToCompany = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        PercentageHolding = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLLenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Account_RefNumber = c.Int(nullable: false),
                        TypeOfFacility = c.String(),
                        AmountOfFacility = c.Int(nullable: false),
                        RepaymentPeriod = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        RepaymentTerms = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.ConsentToSellGamingMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamingEquipmentId = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        FullNameOfApplicant = c.String(),
                        Address = c.String(),
                        Nationality = c.String(),
                        MakeOfMachine = c.String(),
                        SerialNumber = c.Int(nullable: false),
                        NatureOfProposedTransaction = c.String(),
                        NatureOfProposedBuyer_Hirer_Consignee = c.String(),
                        AddressOfProposedBuyer_Hirer_Consignee = c.String(),
                        NationalityOfProposedBuyer_Hirer_Consignee = c.String(),
                        NameOfProposedPremisesForMachine = c.String(),
                        ProposedTown_CityForMachine = c.String(),
                        NameOfPresentPremisesForMAchine = c.String(),
                        PresentTown_CityForMachine = c.String(),
                        NumberOfPresentGamblingMachinesLicense = c.Int(nullable: false),
                        Is_TrueOwnerOfMachine = c.Boolean(nullable: false),
                        DateOfExpiryOfPresentLicense = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SignatureOfApplicant = c.String(),
                        ConsentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.GamingEquipments", t => t.GamingEquipmentId)
                .Index(t => t.GamingEquipmentId)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.GamingEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MachineReference = c.Int(nullable: false),
                        DateOfAquisition = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EquipmentName = c.String(),
                        EquipmentSerialNumber = c.String(),
                        PurposeOfEquipment = c.String(),
                        EquipmentManfacturer = c.String(),
                        EquipmentModel = c.String(),
                        EquipmentLocation = c.String(),
                        Region = c.Int(nullable: false),
                        CurrentStatus = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.ImportGamingMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamingEquipmentId = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        FullNameOfApplicant = c.String(),
                        Address = c.String(),
                        Nationality = c.String(),
                        MakeOfMachine = c.String(),
                        SerialNumber = c.Int(nullable: false),
                        CountryOfOrigin = c.String(),
                        CostOfMachine = c.Int(nullable: false),
                        Is_MachineImportForResale = c.Boolean(nullable: false),
                        NameOfProposedPremisesForMachine = c.String(),
                        ProposedTown_CityForMachine = c.String(),
                        NameOfPresentPremisesForMAchine = c.String(),
                        PresentTown_CityForMachine = c.String(),
                        NumberOfPresentGamblingMachinesLicense = c.Int(nullable: false),
                        Is_TrueOwnerOfMachine = c.Boolean(nullable: false),
                        DateOfExpiryOfPresentLicense = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Signature = c.String(),
                        ImportationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.GamingEquipments", t => t.GamingEquipmentId)
                .Index(t => t.GamingEquipmentId)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.LicenseOperateGamingMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamingEquipmentId = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        FullNameOfApplicant = c.String(),
                        Address = c.String(),
                        Nationality = c.String(),
                        MakeOfMachine = c.String(),
                        SerialNumber = c.Int(nullable: false),
                        DateOfImportation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ParticularsOfImportLicense = c.String(),
                        CountryOfOrigin = c.String(),
                        CostOfMachine = c.Int(nullable: false),
                        AmountOfCustomDutyPaid = c.Int(nullable: false),
                        ReceiptNumberOfCustomDutyPaid = c.Int(nullable: false),
                        IncomeTaxClearanceCertificateNumber = c.Int(nullable: false),
                        NumberOfPreviousLicense = c.Int(nullable: false),
                        PreviousLicenseIssuedBy = c.String(),
                        FeePaidForPreviousLicense = c.Int(nullable: false),
                        DateOfExpiryForPreviousLicense = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NameOfProposedPremisesForMachine = c.String(),
                        ProposedTown_CityForMachine = c.String(),
                        NameOfPresentPremisesForMAchine = c.String(),
                        PresentTown_CityForMachine = c.String(),
                        Is_ProposedLocationOwnedByApplicant = c.Boolean(nullable: false),
                        DescriptionOfAcquiringLocation = c.String(),
                        NumberOfPresentGamblingMachinesOwned = c.Int(nullable: false),
                        Is_TrueOwnerOfMachine = c.Boolean(nullable: false),
                        Signature = c.String(),
                        SignatureDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.GamingEquipments", t => t.GamingEquipmentId)
                .Index(t => t.GamingEquipmentId)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.CourtCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuitNumber = c.String(),
                        SuitTitle = c.String(),
                        SuitDescription = c.String(),
                        SuitDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SolicitorID = c.String(),
                        AMLCompanyProfileID = c.Int(),
                        CourtCaseStatus = c.String(),
                        Solicitor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileID)
                .ForeignKey("dbo.Solicitors", t => t.Solicitor_Id)
                .Index(t => t.AMLCompanyProfileID)
                .Index(t => t.Solicitor_Id);
            
            CreateTable(
                "dbo.CourtCaseJudgements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourtCaseId = c.Int(nullable: false),
                        JudgementTitle = c.String(),
                        JudgementDetails = c.String(),
                        Attachment = c.String(),
                        JudgementDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourtCases", t => t.CourtCaseId, cascadeDelete: true)
                .Index(t => t.CourtCaseId);
            
            CreateTable(
                "dbo.CourtCaseReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourtCaseId = c.String(),
                        ReportTitle = c.String(),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReportAttachment = c.String(),
                        ReportDetails = c.String(),
                        CourtCase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourtCases", t => t.CourtCase_Id)
                .Index(t => t.CourtCase_Id);
            
            CreateTable(
                "dbo.Solicitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Country = c.String(),
                        Region = c.String(),
                        SolicitorFullName = c.String(),
                        SolicitorAddress = c.String(),
                        SolicitorEmailAddress = c.String(),
                        AMLCompanyProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfile_Id)
                .Index(t => t.AMLCompanyProfile_Id);
            
            CreateTable(
                "dbo.ExpenseHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseNumber = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HeaderText = c.String(),
                        ApprovedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovedBy = c.String(),
                        ReviewedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedBy = c.String(),
                        ReviewComment = c.String(),
                        ApprovedComment = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.ExpenseLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Int(nullable: false),
                        ExpenseHeaderId = c.Int(nullable: false),
                        ExpenseCategoryID = c.Int(nullable: false),
                        LineitemNumber = c.String(),
                        Narration = c.String(),
                        UnitPrice = c.Int(nullable: false),
                        Units = c.String(),
                        GrossAmount = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                        NetAmount = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseHeaders", t => t.ExpenseHeaderId, cascadeDelete: true)
                .Index(t => t.ExpenseHeaderId)
                .Index(t => t.ExpenseCategoryID);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InspectionRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        InspectionTeamId = c.Int(nullable: false),
                        InspectionReference = c.String(),
                        InspectionStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        InspectionEndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        InspectionCategoryId = c.Int(nullable: false),
                        Justification = c.String(),
                        IsReviewed = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        ReviewComment = c.String(),
                        ApprovalComment = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedBy = c.String(),
                        ApprovedBy = c.String(),
                        InspectionOfficerID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        InspectionTeamMembers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.InspectionTeams", t => t.InspectionTeamId, cascadeDelete: true)
                .ForeignKey("dbo.InspectionTeamMembers", t => t.InspectionTeamMembers_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.InspectionTeamId)
                .Index(t => t.InspectionTeamMembers_Id);
            
            CreateTable(
                "dbo.InspectionTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Description = c.String(),
                        Is_Deleted = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InspectionTeamMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InspectionTeamId = c.String(),
                        InspectionOfficerId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        InspectionTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InspectionOfficers", t => t.InspectionOfficerId, cascadeDelete: true)
                .ForeignKey("dbo.InspectionTeams", t => t.InspectionTeam_Id)
                .Index(t => t.InspectionOfficerId)
                .Index(t => t.InspectionTeam_Id);
            
            CreateTable(
                "dbo.InspectionOfficers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        InspectionOfficerName = c.String(),
                        InspectionReference = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        Country = c.Int(nullable: false),
                        OfficeDesignation = c.String(),
                        Is_Active = c.Boolean(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        InspectionOfficerType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.InvoiceHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        DocumentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HeaderText = c.String(),
                        ApprovedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovedBy = c.String(),
                        ReviewedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedBy = c.String(),
                        ReviewComment = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        ApprovedComment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Int(nullable: false),
                        InvoiceHeaderId = c.Int(nullable: false),
                        LineitemNumber = c.String(),
                        Narration = c.String(),
                        PaymentCateroryID = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        Units = c.String(),
                        GrossAmount = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        NetAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceHeaders", t => t.InvoiceHeaderId, cascadeDelete: true)
                .Index(t => t.InvoiceHeaderId);
            
            CreateTable(
                "dbo.JournalHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        JournalNumber = c.String(),
                        JournalType = c.Int(nullable: false),
                        JournalText = c.String(),
                        JournalDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SourceDocumentReference = c.String(),
                        Period = c.Int(nullable: false),
                        FiscalYear = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        ReviewedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedBy = c.String(),
                        ReviewedComment = c.String(),
                        ApprovedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovedBy = c.String(),
                        ApprovedComment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.JournalLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalHeaderId = c.Int(nullable: false),
                        JournalNumber = c.String(),
                        LineItemNumber = c.Int(nullable: false),
                        GLAccount = c.String(),
                        Narration = c.String(),
                        CreditAmount = c.Double(nullable: false),
                        DebitAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JournalHeaders", t => t.JournalHeaderId, cascadeDelete: true)
                .Index(t => t.JournalHeaderId);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseCode = c.String(),
                        LicenseTitle = c.String(),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        DateIssued = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpireDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateWithdrawn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovedBy = c.String(),
                        ApprovedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedBy = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IssuedBy = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        WithdrawnBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.Memos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoReference = c.String(),
                        MemoTitle = c.String(),
                        MemoDescription = c.String(),
                        MemoType = c.String(),
                        AMLCompanyProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.OffCourtCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LitigationReference = c.String(),
                        CaseTitle = c.String(),
                        CaseDescription = c.String(),
                        AMLCompanyProfileId = c.Int(),
                        LitigationDate = c.String(),
                        LitigationStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.OffCourtCaseReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OffCourtCaseId = c.Int(nullable: false),
                        ReportTitle = c.String(),
                        ReportDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserID = c.Int(nullable: false),
                        ReportAttachment = c.String(),
                        ReportDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OffCourtCases", t => t.OffCourtCaseId, cascadeDelete: true)
                .Index(t => t.OffCourtCaseId);
            
            CreateTable(
                "dbo.OffCourtJudgements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OffCourtCaseId = c.Int(nullable: false),
                        JudgementTitle = c.String(),
                        JudgementDetails = c.String(),
                        Attachment = c.String(),
                        JudgementDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LitigationStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OffCourtCases", t => t.OffCourtCaseId, cascadeDelete: true)
                .Index(t => t.OffCourtCaseId);
            
            CreateTable(
                "dbo.Outlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        OutletTitle = c.String(),
                        HouseNumber = c.String(),
                        StreetName = c.String(),
                        City = c.String(),
                        Region = c.Int(nullable: false),
                        Telephone = c.String(),
                        ContactPerson = c.String(),
                        ContactPersonPhone = c.String(),
                        ContactPersonEmail = c.String(),
                        NumberOfMachines = c.String(),
                        OutletReference = c.String(),
                        Is_Approved = c.Boolean(nullable: false),
                        ApprovalComment = c.String(),
                        Is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.PaymentHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        InvoiceNumber = c.Int(nullable: false),
                        LineitemNumber = c.Int(nullable: false),
                        AmountDue = c.Int(nullable: false),
                        AmountPaid = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        PaymentType = c.String(),
                        TotalPercentagePaid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.PaymentLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PaymentHeaderId = c.Int(nullable: false),
                        PaymentDate = c.Int(nullable: false),
                        PaymentOption = c.Int(nullable: false),
                        AmountPaid = c.Int(nullable: false),
                        PaymentReference = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        TotalPercentagePaid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentHeaders", t => t.PaymentHeaderId)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PaymentHeaderId);
            
            CreateTable(
                "dbo.PNFAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        AttachmentCategory = c.Int(nullable: false),
                        ReferenceNumber = c.String(),
                        FilePath = c.String(),
                        FileName = c.String(),
                        UploadedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        DocumentType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFPersonalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        Surname = c.String(),
                        FirstAndMiddleNames = c.String(),
                        PreviousNames = c.String(),
                        ReasonsForChangeOfName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfBirth = c.String(),
                        Hometown = c.String(),
                        PresentNationality = c.Int(nullable: false),
                        PreviousNationality = c.Int(nullable: false),
                        PassportType = c.Int(nullable: false),
                        PassportNumber = c.Int(nullable: false),
                        DateOfPassportIssue = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfPassportIssue = c.String(),
                        PassportExpiryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlacesTravelledTo = c.String(),
                        DateOfTravels = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Hobbies = c.String(),
                        Occupation_Profession = c.String(),
                        FullNameOfFather = c.String(),
                        DateOfBirthOfFather = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfBirthOfFather = c.String(),
                        DateOfDeathOfFather = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HometownOfFather = c.String(),
                        NationalityOfFather = c.String(),
                        OccupationOfFather = c.String(),
                        ResidentialAddressOfFather = c.String(),
                        PopularSpotsCloseToFathersResidence = c.String(),
                        FullNameOfMother = c.String(),
                        DateOfBirthOfMother = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfBirthOfMother = c.String(),
                        DateOfDeathOfMother = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HometownOfMother = c.String(),
                        NationalityOfMother = c.String(),
                        OccupationOfMother = c.String(),
                        ResidentialAddressOfMother = c.String(),
                        PopularSpotsCloseToMothesResidence = c.String(),
                        BusinessAddressOfMother = c.String(),
                        NameOfProfessionalParties = c.String(),
                        NameOfSocialParties = c.String(),
                        NameOfPoliticalParties = c.String(),
                        NameOfCharitabledOrganizations = c.String(),
                        MaritalStatus = c.Int(nullable: false),
                        DateOfMarriage = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfMarriage = c.String(),
                        MarriageCertificateNumber = c.Int(nullable: false),
                        NameOfOneOfKeyWitness = c.String(),
                        AddressOfOneOfKeyWitness = c.String(),
                        FullNameOfFormerSpouse = c.String(),
                        PlaceOfBirthOfFormerSpouse = c.String(),
                        DateOfBirthOfFormerSpouse = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BusinessAddressOfFormerSpouse = c.String(),
                        ResidentialAddressOfFormerSpouse = c.String(),
                        OccupationOfFormerSpouse = c.String(),
                        NamesOfChildrenWithPresentSpouse = c.String(),
                        AgesOfChildrenWithPresentSpouse = c.String(),
                        Is_Single = c.Boolean(nullable: false),
                        FullNameOfPresentGirlOrBoyfriend = c.String(),
                        ResidentialAddressOfPresentGirlOrBoyfriend = c.String(),
                        BusinessAddressOfPresentGirlOrBoyfriend = c.String(),
                        OccupationOfPresentGirlOrBoyfriend = c.String(),
                        FullNameOfFormerGirlOrBoyfriend = c.String(),
                        ResidentialAddressOfFormerGirlOrBoyfriend = c.String(),
                        BusinessAddressOfFormerGirlOrBoyfriend = c.String(),
                        OccupationOfFormerGirlOrBoyfriend = c.String(),
                        NamesOfChildren = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        AgesOfChildren_For_Is_Single = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.PNFCompanyProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        NameOfCompany = c.String(),
                        BusinessAddressOfCompany = c.String(),
                        HouseNumberOfCompany = c.String(),
                        StreetNameOfCompany = c.String(),
                        TownOfCompany = c.String(),
                        PopularSpotCloseToCompany = c.String(),
                        DateOfIncorporation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RegistrationNumber = c.Int(nullable: false),
                        NumberOfInitialWorkForce = c.Int(nullable: false),
                        NameOfBankers = c.String(),
                        AddressOfBankers = c.String(),
                        NameOfAuditors = c.String(),
                        AddressOfAuditors = c.String(),
                        NameOfOtherCompanyDirectors = c.String(),
                        AddressofOtherCompanyDirectors = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        ReasonsForEstablishingCompany = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFContactInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        CurrentResidentialAddress = c.String(),
                        HouseNumber = c.String(),
                        Street = c.String(),
                        Suburb = c.String(),
                        Town = c.String(),
                        District = c.String(),
                        State = c.String(),
                        Region = c.String(),
                        PopularSpotsOrPersonalityNearResidence = c.String(),
                        HomeNumber = c.String(),
                        MobileNumber = c.Int(nullable: false),
                        FaxNumber = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        CorrespondenceAddress = c.String(),
                        PreviousResidenceAddress = c.String(),
                        PreviousHouseNumber = c.String(),
                        PreviousStreet = c.String(),
                        PreviousTown = c.String(),
                        PreviousDistrict = c.String(),
                        PreviousRegion = c.String(),
                        HomeTownAddress = c.String(),
                        HomeTownHouseNumber = c.String(),
                        HomeTownStreet = c.String(),
                        HomeTownName = c.String(),
                        HomeTownDistrict = c.String(),
                        HomeTownRegion = c.String(),
                        EmploymentAddress = c.String(),
                        BusinessName = c.String(),
                        BusinessStreetName = c.String(),
                        BusinessTown = c.String(),
                        BusinessState = c.String(),
                        BusinessRegion = c.String(),
                        AnyClosePopularSpotToBusiness = c.String(),
                        EmployersTelephoneNumber = c.Int(nullable: false),
                        EmployersFaxNumber = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        EmployesEmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFEconomicStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        Is_AssetOwner = c.Boolean(nullable: false),
                        AssetParticulars_Description = c.String(),
                        LocationOfAsset = c.String(),
                        DescriptionOfObtainingAsset = c.String(),
                        TaxCertificateNumberOfAsset = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        IssueDateOfTaxCertificateOfAsset = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFEducationHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        NameOfSeniorSecondarySchool = c.String(),
                        AddressOfSeniorSecondarySchool = c.String(),
                        DateBeganSeniorSecondarySchool = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateCompletedSeniorSecondarySchool = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        QualificationAchievedFromSeniorSecondarySchool = c.String(),
                        GradesAchievedFromSeniorSecondarySchool = c.String(),
                        NameOfCollege = c.String(),
                        AddressOfCollege = c.String(),
                        DateBeganCollege = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateCompletedCollege = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        QualificationAchievedFromCollege = c.String(),
                        GradesAchievedFromCollege = c.String(),
                        NameOfHigher_Prof_VocInstitution = c.String(),
                        Is_FullTimeStudy = c.Boolean(nullable: false),
                        Is_PartTimeStudy = c.Boolean(nullable: false),
                        AddressOfHigher_Prof_VocInstitution = c.String(),
                        DateAttendedHigher_Prof_VocInstitution = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SubjectsStudiedAtHigher_Prof_VocInstitution = c.String(),
                        DegreeTitleFromHigher_Prof_VocInstitution = c.String(),
                        GradesAchievedFromHigher_Prof_VocInstitution = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        QualificationAchievedFromHigher_Prof_VocInstitution = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFEmploymentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        OrganisationFullName = c.String(),
                        Is_Apprenticeship = c.Boolean(nullable: false),
                        Is_SelfEmployment = c.Boolean(nullable: false),
                        Is_UnEmployment = c.Boolean(nullable: false),
                        Is_NationalService = c.Boolean(nullable: false),
                        AddressOFOrganisation = c.String(),
                        TelephoneNumberOfOrganisation = c.Int(nullable: false),
                        EmploymentStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EmploymentEndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Post = c.String(),
                        DutiesDescription = c.String(),
                        Is_SecurityService_Employee = c.Boolean(nullable: false),
                        BranchOfService_Unit = c.String(),
                        Rank_Position = c.String(),
                        ServiceNumber = c.Int(nullable: false),
                        DateOfEnlistment = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PlaceOfEnlistment = c.String(),
                        DateOfLeaving = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        ReasonsForLeaving = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFExamsTakens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        NameOfExam = c.String(),
                        NameOfExaminingAuthority_Board = c.String(),
                        ExamTitle = c.String(),
                        IndexNumber = c.Int(nullable: false),
                        ResultOfExam = c.String(),
                        PlaceOFExam = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        DateOfExam = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFInformalEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        NameOfTrainingCenter_Place = c.String(),
                        NameOfTrainer = c.String(),
                        AddressOfTrainer = c.String(),
                        SpecialisedSkills_TrainingAcquired = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        DateAcquired = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFReferees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        FullNameOfAssociate = c.String(),
                        BusinessAddressOfAssociate = c.String(),
                        PopularSpotCloseToResidenceOfAssociate = c.String(),
                        ResidentialAddressOfAssociate = c.String(),
                        Is_Student = c.Boolean(nullable: false),
                        HallOfResidenceOfStudentAssociate = c.String(),
                        CurrentDesignationOfAssociate = c.String(),
                        FullNameOfCharacterReferee = c.String(),
                        BusinessAddressOfChararcterReferee = c.String(),
                        ResidentialAddressOfChararcterReferee = c.String(),
                        PopularSpotCloseToResidenceOfChararcterReferee = c.String(),
                        TelephoneNumberOfCharacterReferee = c.Int(nullable: false),
                        EmailAddressOfCharacterReferee = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        CurrentDesignationOfCharacterReferee = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PNFSecurityClearances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        PNFPersonalDetailsId = c.Int(nullable: false),
                        Is_LawOffender = c.Boolean(nullable: false),
                        OffenseDescription = c.String(),
                        Comments_AdditionalInformation = c.String(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Declared = c.Boolean(nullable: false),
                        Signature = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.PNFPersonalDetails", t => t.PNFPersonalDetailsId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId)
                .Index(t => t.PNFPersonalDetailsId);
            
            CreateTable(
                "dbo.PurchaseHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountPayableId = c.Int(nullable: false),
                        PurchaseReference = c.String(),
                        PurchaseDate = c.String(),
                        PurchaseHeaderText = c.Int(nullable: false),
                        ReviewedBy = c.String(),
                        ReviewedComment = c.String(),
                        ReviewDate = c.String(),
                        ApprovedBy = c.Boolean(nullable: false),
                        ApprovedComment = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovalDate = c.Boolean(nullable: false),
                        AMLCompanyProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountPayables", t => t.AccountPayableId, cascadeDelete: true)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfile_Id)
                .Index(t => t.AccountPayableId)
                .Index(t => t.AMLCompanyProfile_Id);
            
            CreateTable(
                "dbo.PurchaseLineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseHeaderId = c.Int(nullable: false),
                        LineItemNumber = c.String(),
                        Narration = c.String(),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        GrossPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        NetPrice = c.Double(nullable: false),
                        Is_Delivered = c.Boolean(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AmountPaid = c.Double(nullable: false),
                        PaymentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PaymentReference = c.String(),
                        AMLCompanyProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseHeaders", t => t.PurchaseHeaderId, cascadeDelete: true)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfile_Id)
                .Index(t => t.PurchaseHeaderId)
                .Index(t => t.AMLCompanyProfile_Id);
            
            CreateTable(
                "dbo.QueryRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountPayableId = c.Int(nullable: false),
                        Reference = c.String(),
                        QueryTitle = c.String(),
                        QueryDescription = c.String(),
                        QueryCategory = c.Int(nullable: false),
                        ResponseTitle = c.String(),
                        ResponseDate = c.String(),
                        Response = c.String(),
                        L1ReviewComment = c.String(),
                        ReviewStatus = c.Int(nullable: false),
                        L1ReviewedBy = c.String(),
                        L1ReviewedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        L2ReviewComment = c.String(),
                        L2ReviewStatus = c.Int(nullable: false),
                        L2ReviewedBy = c.String(),
                        L2ReviewedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FinalResolution = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        FinalResolutionStatus = c.Int(nullable: false),
                        AMLCompanyProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountPayables", t => t.AccountPayableId, cascadeDelete: true)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfile_Id)
                .Index(t => t.AccountPayableId)
                .Index(t => t.AMLCompanyProfile_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        TicketNumber = c.Int(nullable: false),
                        DateRaised = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Subject = c.String(),
                        TicketStatus = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.TicketMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Message = c.String(),
                        Response = c.String(),
                        MessageDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ResponseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ResponseBy = c.String(),
                        MessageBy = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        AMLCompanyProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfile_Id)
                .Index(t => t.TicketId)
                .Index(t => t.AMLCompanyProfile_Id);
            
            CreateTable(
                "dbo.AMLPendingCivilActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        CivilActionDescription = c.String(),
                        CivilActionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        AmountOwed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLPendingProsecutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfAccused = c.String(),
                        DesignationOfAccused = c.String(),
                        ProsecutionDescription = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        NameOfProsecutor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLShareholders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfShareholder = c.String(),
                        Address = c.String(),
                        Shareholding = c.String(),
                        Percentage = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        NumberOfShareholdersWithLessThanFivePercent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLSubsidiaryAssociates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileId = c.Int(nullable: false),
                        NameOfCompany = c.String(),
                        RegistrationNumber = c.Int(nullable: false),
                        PlaceOfIncorporation = c.String(),
                        NatureOfBusiness = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        PercentageShareholding = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileId, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileId);
            
            CreateTable(
                "dbo.AMLVestedInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AMLCompanyProfileID = c.Int(nullable: false),
                        Is_Interest_InPerson = c.Boolean(nullable: false),
                        Is_Interest_InCompany = c.Boolean(nullable: false),
                        InterestDescription = c.String(),
                        Is_Supporting_Company = c.Boolean(nullable: false),
                        Is_Supporting_Business = c.Boolean(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        SupportDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AMLCompanyProfiles", t => t.AMLCompanyProfileID, cascadeDelete: true)
                .Index(t => t.AMLCompanyProfileID);
            
            CreateTable(
                "dbo.ChartOfAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GLAccount = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComplianceTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FullName = c.String(),
                        Description = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        Country = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        Is_Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InspectionReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        InspectionRequestId = c.Int(nullable: false),
                        InspectionStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        InspectionEndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        InspectionCategoryId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        InspectionResult = c.String(),
                        ReviewedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReviewedBy = c.String(),
                        ApprovedBy = c.String(),
                        InspectionOfficerId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ReviewComment = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        InspectionReportAttachment = c.String(),
                        ApprovedComment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InspectionRequests", t => t.InspectionRequestId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.InspectionRequestId);
            
            CreateTable(
                "dbo.InspectionReportCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Is_Deleted = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MajorAccountCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        CreatedDate = c.String(),
                        CompleteCOA = c.String(),
                        Is_Deleted = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MinorAccountCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MajorAccountCodeId = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreatedDate = c.String(),
                        CompleteCOA = c.String(),
                        Is_Deleted = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MajorAccountCodes", t => t.MajorAccountCodeId, cascadeDelete: true)
                .Index(t => t.MajorAccountCodeId);
            
            CreateTable(
                "dbo.MinorMinorAccountCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MajorAccountCodeId = c.Int(nullable: false),
                        MinorAccountCodeId = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreatedDate = c.String(),
                        CompleteCOA = c.String(),
                        AccountType = c.Int(nullable: false),
                        Is_Deleted = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MajorAccountCodes", t => t.MajorAccountCodeId, cascadeDelete: true)
                .ForeignKey("dbo.MinorAccountCodes", t => t.MinorAccountCodeId)
                .Index(t => t.MajorAccountCodeId)
                .Index(t => t.MinorAccountCodeId);
            
            AlterColumn("dbo.AspNetUsers", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "TimeStamp", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MinorMinorAccountCodes", "MinorAccountCodeId", "dbo.MinorAccountCodes");
            DropForeignKey("dbo.MinorMinorAccountCodes", "MajorAccountCodeId", "dbo.MajorAccountCodes");
            DropForeignKey("dbo.MinorAccountCodes", "MajorAccountCodeId", "dbo.MajorAccountCodes");
            DropForeignKey("dbo.InspectionReports", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InspectionReports", "InspectionRequestId", "dbo.InspectionRequests");
            DropForeignKey("dbo.ComplianceTeams", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AMLVestedInterests", "AMLCompanyProfileID", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLSubsidiaryAssociates", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLShareholders", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLPendingProsecutions", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLPendingCivilActions", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLAgreements", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AMLCompanyProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketMessages", "AMLCompanyProfile_Id", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.TicketMessages", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.Solicitors", "AMLCompanyProfile_Id", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.QueryRequests", "AMLCompanyProfile_Id", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.QueryRequests", "AccountPayableId", "dbo.AccountPayables");
            DropForeignKey("dbo.PurchaseLineItems", "AMLCompanyProfile_Id", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PurchaseHeaders", "AMLCompanyProfile_Id", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PurchaseLineItems", "PurchaseHeaderId", "dbo.PurchaseHeaders");
            DropForeignKey("dbo.PurchaseHeaders", "AccountPayableId", "dbo.AccountPayables");
            DropForeignKey("dbo.PNFSecurityClearances", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFSecurityClearances", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFReferees", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFReferees", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFInformalEducations", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFInformalEducations", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFExamsTakens", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFExamsTakens", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFEmploymentHistories", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFEmploymentHistories", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFEducationHistories", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFEducationHistories", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFEconomicStatus", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFEconomicStatus", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFContactInformations", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFContactInformations", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFCompanyProfiles", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFCompanyProfiles", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFAttachments", "PNFPersonalDetailsId", "dbo.PNFPersonalDetails");
            DropForeignKey("dbo.PNFPersonalDetails", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PNFAttachments", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PaymentLines", "PaymentHeaderId", "dbo.PaymentHeaders");
            DropForeignKey("dbo.PaymentLines", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.PaymentHeaders", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.Outlets", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.OffCourtJudgements", "OffCourtCaseId", "dbo.OffCourtCases");
            DropForeignKey("dbo.OffCourtCaseReports", "OffCourtCaseId", "dbo.OffCourtCases");
            DropForeignKey("dbo.OffCourtCases", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.Memos", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.Licenses", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.JournalLines", "JournalHeaderId", "dbo.JournalHeaders");
            DropForeignKey("dbo.JournalHeaders", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.InvoiceHeaders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InvoiceLines", "InvoiceHeaderId", "dbo.InvoiceHeaders");
            DropForeignKey("dbo.InvoiceHeaders", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.InspectionRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InspectionTeamMembers", "InspectionTeam_Id", "dbo.InspectionTeams");
            DropForeignKey("dbo.InspectionRequests", "InspectionTeamMembers_Id", "dbo.InspectionTeamMembers");
            DropForeignKey("dbo.InspectionTeamMembers", "InspectionOfficerId", "dbo.InspectionOfficers");
            DropForeignKey("dbo.InspectionOfficers", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.InspectionRequests", "InspectionTeamId", "dbo.InspectionTeams");
            DropForeignKey("dbo.InspectionRequests", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.ExpenseLines", "ExpenseHeaderId", "dbo.ExpenseHeaders");
            DropForeignKey("dbo.ExpenseLines", "ExpenseCategoryID", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseHeaders", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.CourtCases", "Solicitor_Id", "dbo.Solicitors");
            DropForeignKey("dbo.CourtCaseReports", "CourtCase_Id", "dbo.CourtCases");
            DropForeignKey("dbo.CourtCaseJudgements", "CourtCaseId", "dbo.CourtCases");
            DropForeignKey("dbo.CourtCases", "AMLCompanyProfileID", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.ConsentToSellGamingMachines", "GamingEquipmentId", "dbo.GamingEquipments");
            DropForeignKey("dbo.LicenseOperateGamingMachines", "GamingEquipmentId", "dbo.GamingEquipments");
            DropForeignKey("dbo.LicenseOperateGamingMachines", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.ImportGamingMachines", "GamingEquipmentId", "dbo.GamingEquipments");
            DropForeignKey("dbo.ImportGamingMachines", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.GamingEquipments", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.ConsentToSellGamingMachines", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLLenders", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLHoldingCompanies", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLConvictions", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLCompanyLawyers", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLCivilActions", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLCertifications", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLBankAccounts", "AMLCompanyProfileId", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLAttachments", "AMLCompanyProfileID", "dbo.AMLCompanyProfiles");
            DropForeignKey("dbo.AMLAgreements", "AMLCompanyProfileID", "dbo.AMLCompanyProfiles");
            DropIndex("dbo.MinorMinorAccountCodes", new[] { "MinorAccountCodeId" });
            DropIndex("dbo.MinorMinorAccountCodes", new[] { "MajorAccountCodeId" });
            DropIndex("dbo.MinorAccountCodes", new[] { "MajorAccountCodeId" });
            DropIndex("dbo.InspectionReports", new[] { "InspectionRequestId" });
            DropIndex("dbo.InspectionReports", new[] { "UserId" });
            DropIndex("dbo.ComplianceTeams", new[] { "UserId" });
            DropIndex("dbo.AMLVestedInterests", new[] { "AMLCompanyProfileID" });
            DropIndex("dbo.AMLSubsidiaryAssociates", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLShareholders", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLPendingProsecutions", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLPendingCivilActions", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.TicketMessages", new[] { "AMLCompanyProfile_Id" });
            DropIndex("dbo.TicketMessages", new[] { "TicketId" });
            DropIndex("dbo.Tickets", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.QueryRequests", new[] { "AMLCompanyProfile_Id" });
            DropIndex("dbo.QueryRequests", new[] { "AccountPayableId" });
            DropIndex("dbo.PurchaseLineItems", new[] { "AMLCompanyProfile_Id" });
            DropIndex("dbo.PurchaseLineItems", new[] { "PurchaseHeaderId" });
            DropIndex("dbo.PurchaseHeaders", new[] { "AMLCompanyProfile_Id" });
            DropIndex("dbo.PurchaseHeaders", new[] { "AccountPayableId" });
            DropIndex("dbo.PNFSecurityClearances", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFSecurityClearances", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFReferees", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFReferees", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFInformalEducations", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFInformalEducations", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFExamsTakens", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFExamsTakens", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFEmploymentHistories", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFEmploymentHistories", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFEducationHistories", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFEducationHistories", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFEconomicStatus", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFEconomicStatus", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFContactInformations", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFContactInformations", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFCompanyProfiles", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFCompanyProfiles", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFPersonalDetails", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PNFAttachments", new[] { "PNFPersonalDetailsId" });
            DropIndex("dbo.PNFAttachments", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PaymentLines", new[] { "PaymentHeaderId" });
            DropIndex("dbo.PaymentLines", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.PaymentHeaders", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.Outlets", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.OffCourtJudgements", new[] { "OffCourtCaseId" });
            DropIndex("dbo.OffCourtCaseReports", new[] { "OffCourtCaseId" });
            DropIndex("dbo.OffCourtCases", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.Memos", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.Licenses", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.JournalLines", new[] { "JournalHeaderId" });
            DropIndex("dbo.JournalHeaders", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.InvoiceLines", new[] { "InvoiceHeaderId" });
            DropIndex("dbo.InvoiceHeaders", new[] { "UserId" });
            DropIndex("dbo.InvoiceHeaders", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.InspectionOfficers", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.InspectionTeamMembers", new[] { "InspectionTeam_Id" });
            DropIndex("dbo.InspectionTeamMembers", new[] { "InspectionOfficerId" });
            DropIndex("dbo.InspectionRequests", new[] { "InspectionTeamMembers_Id" });
            DropIndex("dbo.InspectionRequests", new[] { "InspectionTeamId" });
            DropIndex("dbo.InspectionRequests", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.InspectionRequests", new[] { "UserId" });
            DropIndex("dbo.ExpenseLines", new[] { "ExpenseCategoryID" });
            DropIndex("dbo.ExpenseLines", new[] { "ExpenseHeaderId" });
            DropIndex("dbo.ExpenseHeaders", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.Solicitors", new[] { "AMLCompanyProfile_Id" });
            DropIndex("dbo.CourtCaseReports", new[] { "CourtCase_Id" });
            DropIndex("dbo.CourtCaseJudgements", new[] { "CourtCaseId" });
            DropIndex("dbo.CourtCases", new[] { "Solicitor_Id" });
            DropIndex("dbo.CourtCases", new[] { "AMLCompanyProfileID" });
            DropIndex("dbo.LicenseOperateGamingMachines", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.LicenseOperateGamingMachines", new[] { "GamingEquipmentId" });
            DropIndex("dbo.ImportGamingMachines", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.ImportGamingMachines", new[] { "GamingEquipmentId" });
            DropIndex("dbo.GamingEquipments", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.ConsentToSellGamingMachines", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.ConsentToSellGamingMachines", new[] { "GamingEquipmentId" });
            DropIndex("dbo.AMLLenders", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLHoldingCompanies", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLConvictions", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLCompanyLawyers", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLCivilActions", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLCertifications", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLBankAccounts", new[] { "AMLCompanyProfileId" });
            DropIndex("dbo.AMLAttachments", new[] { "AMLCompanyProfileID" });
            DropIndex("dbo.AMLCompanyProfiles", new[] { "UserId" });
            DropIndex("dbo.AMLAgreements", new[] { "AMLCompanyProfileID" });
            DropIndex("dbo.AMLAgreements", new[] { "UserId" });
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "TimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CreatedDate", c => c.DateTime(nullable: false));
            DropTable("dbo.MinorMinorAccountCodes");
            DropTable("dbo.MinorAccountCodes");
            DropTable("dbo.MajorAccountCodes");
            DropTable("dbo.InspectionReportCategories");
            DropTable("dbo.InspectionReports");
            DropTable("dbo.ComplianceTeams");
            DropTable("dbo.ChartOfAccounts");
            DropTable("dbo.AMLVestedInterests");
            DropTable("dbo.AMLSubsidiaryAssociates");
            DropTable("dbo.AMLShareholders");
            DropTable("dbo.AMLPendingProsecutions");
            DropTable("dbo.AMLPendingCivilActions");
            DropTable("dbo.TicketMessages");
            DropTable("dbo.Tickets");
            DropTable("dbo.QueryRequests");
            DropTable("dbo.PurchaseLineItems");
            DropTable("dbo.PurchaseHeaders");
            DropTable("dbo.PNFSecurityClearances");
            DropTable("dbo.PNFReferees");
            DropTable("dbo.PNFInformalEducations");
            DropTable("dbo.PNFExamsTakens");
            DropTable("dbo.PNFEmploymentHistories");
            DropTable("dbo.PNFEducationHistories");
            DropTable("dbo.PNFEconomicStatus");
            DropTable("dbo.PNFContactInformations");
            DropTable("dbo.PNFCompanyProfiles");
            DropTable("dbo.PNFPersonalDetails");
            DropTable("dbo.PNFAttachments");
            DropTable("dbo.PaymentLines");
            DropTable("dbo.PaymentHeaders");
            DropTable("dbo.Outlets");
            DropTable("dbo.OffCourtJudgements");
            DropTable("dbo.OffCourtCaseReports");
            DropTable("dbo.OffCourtCases");
            DropTable("dbo.Memos");
            DropTable("dbo.Licenses");
            DropTable("dbo.JournalLines");
            DropTable("dbo.JournalHeaders");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.InvoiceHeaders");
            DropTable("dbo.InspectionOfficers");
            DropTable("dbo.InspectionTeamMembers");
            DropTable("dbo.InspectionTeams");
            DropTable("dbo.InspectionRequests");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.ExpenseLines");
            DropTable("dbo.ExpenseHeaders");
            DropTable("dbo.Solicitors");
            DropTable("dbo.CourtCaseReports");
            DropTable("dbo.CourtCaseJudgements");
            DropTable("dbo.CourtCases");
            DropTable("dbo.LicenseOperateGamingMachines");
            DropTable("dbo.ImportGamingMachines");
            DropTable("dbo.GamingEquipments");
            DropTable("dbo.ConsentToSellGamingMachines");
            DropTable("dbo.AMLLenders");
            DropTable("dbo.AMLHoldingCompanies");
            DropTable("dbo.AMLConvictions");
            DropTable("dbo.AMLCompanyLawyers");
            DropTable("dbo.AMLCivilActions");
            DropTable("dbo.AMLCertifications");
            DropTable("dbo.AMLBankAccounts");
            DropTable("dbo.AMLAttachments");
            DropTable("dbo.AMLCompanyProfiles");
            DropTable("dbo.AMLAgreements");
            DropTable("dbo.AccountPayables");
        }
    }
}
