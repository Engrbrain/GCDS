using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZenGrantService.Models
{
    public class GamingEquiment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MachineReference { get; set; }
        public string ImportationLicenseID { get; set; }
        public string InstallationLicenseID { get; set; }
        public DateTime DateOfAquisition { get; set; }
        public string EquipmentName { get; set; }
        public region EquipmentSerialNumber { get; set; }
        public string PurposeOfEquipment { get; set; }
        public string EquipmentManfacturer { get; set; }
        public string EquipmentModel { get; set; }
        public currentstatus CurrentStatus { get; set; }

    }
}