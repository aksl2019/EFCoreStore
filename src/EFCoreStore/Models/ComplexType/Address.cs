using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [ComplexType]
    public class DinnerAddress
    {
        //[Key]
        //[ForeignKey("Student")]
        //[Column("AddressId")]
        //public int AddressId { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Contry")]
        public string Contry { get; set; }

        [Required]
        [StringLength(256)]
        [Column("State")]
        public string State { get; set; }

        [Required]
        [StringLength(256)]
        [Column("City")]
        public string City { get; set; }

        //[StringLength(512)]
        //[Column("Street", Order = 3)]
        //public string Street { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Address1")]
        public string Address1 { get; set; }

        [StringLength(1024)]
        [Column("Address2")]
        public string Address2 { get; set; }

        [StringLength(32)]
        [Column("PostCode")]
        public string PostCode { get; set; }
    }
}
