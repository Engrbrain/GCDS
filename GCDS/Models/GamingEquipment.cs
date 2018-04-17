using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCDS.Models
{
    public class GamingEquipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MachineReference { get; set; }
        public DateTime DateOfAquisition { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentSerialNumber { get; set; }
        public string PurposeOfEquipment { get; set; }
        public string EquipmentManfacturer { get; set; }
        public string EquipmentModel { get; set; }
        public string EquipmentLocation { get; set; }
        public enumManager.region Region { get; set; }
        public enumManager.EquipmentStatus CurrentStatus { get; set; }

        public ICollection<ConsentToSellGamingMachines> ConsentToSellGamingMachines { get; set; }
        public ICollection<ImportGamingMachine> ImportGamingMachine { get; set; }
        
    }
}