using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [Column(Order = 1)]
        public int AddressId { get; set; }

        [Column(Order = 2)]
        [Required]
        [StringLength(1024)]
        public string Contry { get; set; }

        [Column(Order = 3)]
        [Required]
        [StringLength(256)]
        public string State { get; set; }

        [Column( Order = 4)]
        [Required]
        [StringLength(256)]
        public string City { get; set; }

        //[Required]
        //[StringLength(1024, MinimumLength = 3)]
        //[Column("Address1", Order = 5)]
        //public string Address1 { get; set; }

        //[StringLength(1024, MinimumLength = 3)]
        //[Column("Address2", Order = 6)]
        //public string Address2 { get; set; }

        //[StringLength(32, MinimumLength = 5)]
        //[Column("PostCode", Order = 7)]
        //public string PostCode { get; set; }
    }
}
