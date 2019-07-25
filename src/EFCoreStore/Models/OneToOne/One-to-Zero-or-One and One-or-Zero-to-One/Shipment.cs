using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    //Shipment 0.1 to  1 Address
    [Table("Shipment")]
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }

        [Required]
        [StringLength(1024)]
        public string State { get; set; }

        public int DeliveryAddressId { get; set; }

        [ForeignKey("DeliveryAddressId")]
        public virtual Address DeliveryAddress { get; set; }
    }
}
