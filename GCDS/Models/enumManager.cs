using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class enumManager
    {
        public enum InspectionStatus
        {
            Approved,
            Ongoing,
            Complete,
            Rejected

        }

        public enum InvoiceStatus
        {
            Created,
            Reviewed,
            Approved,
            Paid,
            AwaitngPayment,
            Cancelled
        }
        

        public enum PaymentStatus
        {
            Created,
            Reviewed,
            Approved,
            Paid,
            AwaitngPayment,
            Cancelled
        }
        public enum MaritalStatus
        {
            Single,
            Married,
            Engaged,
            Divorced,
            Window,
            Windower
        }
       

        public enum MachineAttachmentCategory
        {
            [Display(Name = "Evidence of Last Tax Payment on Asset")]
            ImportLicense,
            [Display(Name = "Income Tax Clearance ")]
            IncomeTax,
            [Display(Name = "Custom Duty Paid")]
            CustomDutyPaid,
            [Display(Name = "Agreement/Evidence of Allocation of Location")]
            AllocationOfLocation,
            [Display(Name = "Other Relevant Document")]
            OtherRelevantDocument

        }

        public enum PNFAttachmentCategory
        {
            [Display(Name = "Asset Particulars")]
            AssetParticulars,
            [Display(Name = "Evidence of Last Tax Payment On Asset")]
            TaxPaymentOnAsset,
            [Display(Name = "Other Relevant Document")]
            OtherRelevantDocument
        }

        public enum AMLAttachmentCategory
        {
            [Display(Name = "Coporate Family Tree Diagram (Holding Company to Company & subsidiary)")]
            HoldingCorporateFamilyTree,
            [Display(Name = "Coporate Family Tree Diagram (Parent Company to Subsidiaries & Associates)")]
            ParentCompanyFamilyTree,
            [Display(Name = "Passport Sized Pictures")]
            Passport,
            [Display(Name = "School Certificate")]
            SchoolCertifiicate,
            [Display(Name = "Member of Professional Association")]
            ProfessionalAssociation,
            [Display(Name = "Employee History")]
            EmployeeHistory,
            [Display(Name = "Economic Status(Asset Declaration)")]
            EconomicStatus,
            [Display(Name = "Other Relevant Document)")]
            OtherRelevantDocument
        }

        public enum LitigationStatus
        {
            Preparation,
            OffCourtDeliberations,
            InCourt,
            InCourtDeliberations,
            Resolved,
            Judgement,
            JudgementExecution,
            JudgementApeal,
        }

    }
}
