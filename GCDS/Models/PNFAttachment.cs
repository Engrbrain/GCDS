using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileId { get; set; }
        public virtual AMLCompanyProfile AMLCompanyProfile { get; set; }
        public int PNFPersonalDetailsId { get; set; }
        public virtual PNFPersonalDetails PNFPersonalDetails { get; set; }
        public enumManager.PNFAttachmentCategory AttachmentCategory { get; set; }
        public string ReferenceNumber { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string DocumentType { get; set; }


    }
}