using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFExamsTaken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public int PNFPersonalDetailsID { get; set; }
        public string NameOfExam { get; set; }
        public string NameOfExaminingAuthority_Board  { get; set; }
    public string ExamTitle { get; set; }
    public int IndexNumber { get; set; }
    public string ResultOfExam { get; set; }
    public string PlaceOFExam { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }
    public DateTime DateOfExam { get; set; }


}
}