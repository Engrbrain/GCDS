using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFReferees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public int PNFPersonalDetailsID { get; set; }
        public string FullNameOfAssociate { get; set; }
        public string BusinessAddressOfAssociate { get; set; }
        public string PopularSpotCloseToResidenceOfAssociate { get; set; }
        public string ResidentialAddressOfAssociate { get; set; }
        public bool Is_Student { get; set; }
        public string HallOfResidenceOfStudentAssociate { get; set; }
        public string CurrentDesignationOfAssociate { get; set; }
        public string FullNameOfCharacterReferee { get; set; }
        public string BusinessAddressOfChararcterReferee { get; set; }
        public string ResidentialAddressOfChararcterReferee { get; set; }
        public string PopularSpotCloseToResidenceOfChararcterReferee { get; set; }
        public int TelephoneNumberOfCharacterReferee { get; set; }
        public string EmailAddressOfCharacterReferee { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public string CurrentDesignationOfCharacterReferee { get; set; }


    }
}