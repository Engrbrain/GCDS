using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class PNFInformalEducations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AMLCompanyProfileID { get; set; }
        public int PNFPersonalDetailsID { get; set; }
        public string NameOfTrainingCenter_Place { get; set; }
        public string NameOfTrainer { get; set; }
        public string AddressOfTrainer { get; set; }
        public string SpecialisedSkills_TrainingAcquired { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime DateAcquired { get; set; }


    }
}