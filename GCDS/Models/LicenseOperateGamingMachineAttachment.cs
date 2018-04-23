using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class LicenseOperateGamingMachineAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string UserID { get; set; }
        public enumManager.MachineAttachmentCategory AttachmentCategory { get; set; }
        public string ReferenceNumber { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string DocumentType { get; set; }

    }
}