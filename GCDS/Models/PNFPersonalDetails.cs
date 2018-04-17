using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class PNFPersonalDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public string Surname { get; set; }
        public string FirstAndMiddleNames { get; set; }
        public string PreviousNames { get; set; }
        public string ReasonsForChangeOfName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Hometown { get; set; }
        public string PresentNationality { get; set; }
        public string PreviousNationality { get; set; }
        public string PassportType { get; set; }
        public int PassportNumber { get; set; }
        public DateTime DateOfPassportIssue { get; set; }
        public string PlaceOfPassportIssue { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public string PlacesTravelledTo { get; set; }
        public DateTime DateOfTravels { get; set; }
        public string Hobbies { get; set; }
        public string Occupation_Profession  { get; set; }
    public string FullNameOfFather { get; set; }
    public DateTime DateOfBirthOfFather { get; set; }
    public string PlaceOfBirthOfFather { get; set; }
    public DateTime DateOfDeathOfFather { get; set; }
    public string HometownOfFather { get; set; }
    public string NationalityOfFather { get; set; }
    public string OccupationOfFather { get; set; }
    public string ResidentialAddressOfFather { get; set; }
    public string PopularSpotsCloseToFathersResidence  { get; set; }
public string FullNameOfMother { get; set; }
    public DateTime DateOfBirthOfMother { get; set; }
    public string PlaceOfBirthOfMother { get; set; }
    public DateTime DateOfDeathOfMother { get; set; }
    public string HometownOfMother { get; set; }
    public string NationalityOfMother { get; set; }
    public string OccupationOfMother { get; set; }
    public string ResidentialAddressOfMother { get; set; }
    public string PopularSpotsCloseToMothesResidence  { get; set; }
public string BusinessAddressOfMother { get; set; }
    public string NameOfProfessionalParties { get; set; }
    public string NameOfSocialParties { get; set; }
    public string NameOfPoliticalParties { get; set; }
    public string NameOfCharitabledOrganizations { get; set; }
    public enumManager.MaritalStatus MaritalStatus { get; set; }
    public DateTime DateOfMarriage { get; set; }
    public string PlaceOfMarriage { get; set; }
    public int MarriageCertificateNumber { get; set; }
    public string NameOfOneOfKeyWitness { get; set; }
    public string AddressOfOneOfKeyWitness { get; set; }
    public string FullNameOfFormerSpouse { get; set; }
    public string PlaceOfBirthOfFormerSpouse { get; set; }
    public DateTime DateOfBirthOfFormerSpouse { get; set; }
    public string BusinessAddressOfFormerSpouse { get; set; }
    public string ResidentialAddressOfFormerSpouse { get; set; }
    public string OccupationOfFormerSpouse { get; set; }
    public string NamesOfChildrenWithPresentSpouse { get; set; }
    public string AgesOfChildrenWithPresentSpouse { get; set; }
    public bool Is_Single { get; set; }
    public string FullNameOfPresentGirlOrBoyfriend { get; set; }
    public string ResidentialAddressOfPresentGirlOrBoyfriend { get; set; }
    public string BusinessAddressOfPresentGirlOrBoyfriend { get; set; }
    public string OccupationOfPresentGirlOrBoyfriend { get; set; }
    public string FullNameOfFormerGirlOrBoyfriend { get; set; }
    public string ResidentialAddressOfFormerGirlOrBoyfriend { get; set; }
    public string BusinessAddressOfFormerGirlOrBoyfriend { get; set; }
    public string OccupationOfFormerGirlOrBoyfriend { get; set; }
    public string NamesOfChildren { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Is_Deleted { get; set; }
    public int AgesOfChildren_For_Is_Single { get; set; }

}
}