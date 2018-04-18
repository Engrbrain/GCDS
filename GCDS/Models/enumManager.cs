using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
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
        
        public enum journaltype
        {
            [Display(Name = "Payment Journal")]
            PaymentJournal,
            [Display(Name = "Receipt Journal")]
            ReceiptJournal,
            [Display(Name = "General Journal")]
            GeneralJournal,
            [Display(Name = "Reverse Journal")]
            ReversalJournal
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
            [Display(Name = "Economic Status(Asset Declaration")]
            EconomicStatus,
            [Display(Name = "Other Relevant Document")]
            OtherRelevantDocument
        }

        public enum LitigationStatus
        {
            [Display(Name = "Preparation")]
            Preparation,
            [Display(Name = "Off Court Deliberations")]
            OffCourtDeliberations,
            [Display(Name = "Case Taken to Court")]
            InCourt,
            [Display(Name = "In Court Deliberations")]
            InCourtDeliberations,
            [Display(Name = "Resolved")]
            Resolved,
            [Display(Name = "Judgement")]
            Judgement,
            [Display(Name = "Judgement Execution")]
            JudgementExecution,
            [Display(Name = "Judgement Apeal")]
            JudgementApeal,
        }

        public enum region
        {
            [Display(Name = "Ashanti")]
            Ashanti,
            [Display(Name = "Brong-Ahafo")]
            Brong_Ahafo,
            [Display(Name = "Greater Accra")]
            Greater_Accra,
            [Display(Name = "Central")]
            Central,
            [Display(Name = "Eastern")]
            Eastern,
            [Display(Name = "Northern")]
            Northern,
            [Display(Name = "Western")]
            Western,
            [Display(Name = "Upper East")]
            Upper_East,
            [Display(Name = "Upper West")]
            Upper_West,
            [Display(Name = "Volta")]
            Volta

        }

        public enum EquipmentStatus
        {
            [Display(Name = "Running")]
            Running,
            [Display(Name = "Deficient")]
            Deficient,
            [Display(Name = "Closed")]
            Closed,
            [Display(Name = "Uninstalled")]
            Uninstalled
        }

        
            public enum InspectionOfficerType
        {
            [Display(Name = "Internal")]
            Internal,
            [Display(Name = "External")]
            External
        }
        public enum country
        {
            Afghanistan,
            Albania,
            Algeria,
            American_Samoa,
            Andorra,
            Angola,
            Anguilla,
            Antigua_Barbuda,
            Argentina,
            Armenia,
            Aruba,
            Australia,
            Austria,
            Azerbaijan,
            Bahamas,
            Bahrain,
            Bangladesh,
            Barbados,
            Belarus,
            Belgium,
            Belize,
            Benin,
            Bermuda,
            Bhutan,
            Bolivia,
            Bosnia,
            Botswana,
            Brazil,
            BritishVirginIsland,
            Brunei,
            Bulgaria,
            BurkinaFaso,
            Burma,
            Burundi,
            Cambodia,
            Cameroon,
            Canada,
            CapeVerde,
            CaymanIslands,
            CentralAfricanRep,
            Chad,
            Chile,
            China,
            Colombia,
            Comoros,
            Congo,
            CookIslands,
            CostaRica,
            Cote_d_Ivoire,
            Croatia,
            Cuba,
            Cyprus,
            CzechRepublic,
            Denmark,
            Djibouti,
            Dominica,
            DominicanRepublic,
            EastTimor,
            Ecuador,
            Egypt,
            ElSalvador,
            Guinea,
            Eritrea,
            Estonia,
            Ethiopia,
            FaroeIslands,
            Fiji,
            Finland,
            France,
            FrenchGuiana,
            FrenchPolynesia,
            Gabon,
            GambiaThe,
            GazaStrip,
            Georgia,
            Germany,
            Ghana,
            Gibraltar,
            Greece,
            Greenland,
            Grenada,
            Guadeloupe,
            Guam,
            Guatemala,
            Guernsey,
            Guinea_Bissau,
            Guyana,
            Haiti,
            Honduras,
            HongKong,
            Hungary,
            Iceland,
            India,
            Indonesia,
            Iran,
            Iraq,
            Ireland,
            IsleofMan,
            Israel,
            Italy,
            Jamaica,
            Japan,
            Jersey,
            Jordan,
            Kazakhstan,
            Kenya,
            Kiribati,
            KoreaNorth,
            KoreaSouth,
            Kuwait,
            Kyrgyzstan,
            Laos,
            Latvia,
            Lebanon,
            Lesotho,
            Liberia,
            Libya,
            Liechtenstein,
            Lithuania,
            Luxembourg,
            Macau,
            Macedonia,
            Madagascar,
            Malawi,
            Malaysia,
            Maldives,
            Mali,
            Malta,
            MarshallIslands,
            Martinique,
            Mauritania,
            Mauritius,
            Mayotte,
            Mexico,
            MicronesiaFed,
            Moldova,
            Monaco,
            Mongolia,
            Montserrat,
            Morocco,
            Mozambique,
            Namibia,
            Nauru,
            Nepal,
            Netherlands,
            NetherlandsAntilles,
            NewCaledonia,
            NewZealand,
            Nicaragua,
            Niger,
            Nigeria,
            MarianaIslands,
            Norway,
            Oman,
            Pakistan,
            Palau,
            Panama,
            PapuaNewGuinea,
            Paraguay,
            Peru,
            Philippines,
            Poland,
            Portugal,
            PuertoRico,
            Qatar,
            Reunion,
            Romania,
            Russia,
            Rwanda,
            Samoa,
            SanMarino,
            SaoTome,
            SaudiArabia,
            Senegal,
            Serbia,
            Seychelles,
            SierraLeone,
            Singapore,
            Slovakia,
            Slovenia,
            SolomonIslands,
            Somalia,
            SouthAfrica,
            Spain,
            SriLanka,
            Sudan,
            Suriname,
            Swaziland,
            Sweden,
            Switzerland,
            Syria,
            Taiwan,
            Tajikistan,
            Tanzania,
            Thailand,
            Togo,
            Tonga,
            TrinidadNTobago,
            Tunisia,
            Turkey,
            Tuvalu,
            Uganda,
            Ukraine,
            UnitedArabEmirates,
            UnitedKingdom,
            UnitedStates,
            Uruguay,
            Uzbekistan,
            Vanuatu,
            Venezuela,
            Vietnam,
            VirginIslands,
            WallisandFutuna,
            WestBank,
            WesternSahara,
            Yemen,
            Zambia,
            Zimbabwe,
            Others

        }
    }
}
