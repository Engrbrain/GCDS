using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFEducationHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public int PNFPersonalDetailsID { get; set; }
        public string NameOfSeniorSecondarySchool { get; set; }
        public string AddressOfSeniorSecondarySchool { get; set; }
        public DateTime DateBeganSeniorSecondarySchool { get; set; }
        public DateTime DateCompletedSeniorSecondarySchool { get; set; }
        public string QualificationAchievedFromSeniorSecondarySchool { get; set; }
        public string GradesAchievedFromSeniorSecondarySchool { get; set; }
        public string NameOfCollege { get; set; }
        public string AddressOfCollege { get; set; }
        public DateTime DateBeganCollege { get; set; }
        public DateTime DateCompletedCollege { get; set; }
        public string QualificationAchievedFromCollege { get; set; }
        public string GradesAchievedFromCollege { get; set; }
        public string NameOfHigher_Prof_VocInstitution  { get; set; }
    public bool Is_FullTimeStudy { get; set; }
    public bool Is_PartTimeStudy { get; set; }
    public string AddressOfHigher_Prof_VocInstitution  { get; set; }
public DateTime DateAttendedHigher_Prof_VocInstitution  { get; set; }
public string SubjectsStudiedAtHigher_Prof_VocInstitution  { get; set; }
public string DegreeTitleFromHigher_Prof_VocInstitution  { get; set; }
public string GradesAchievedFromHigher_Prof_VocInstitution  { get; set; }
public DateTime TimeStamp { get; set; }
public bool Is_Deleted { get; set; }
public string QualificationAchievedFromHigher_Prof_VocInstitution  { get; set; }

    }
}