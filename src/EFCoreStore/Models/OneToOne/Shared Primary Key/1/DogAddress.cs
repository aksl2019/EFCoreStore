using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("DogAddress")]
    public class DogAddress
    {
        //[Key]
        [Column("DogId", Order = 1)]
        public int DogId { get; set; } //共享主键

        [Required]
        [StringLength(1024)]
        [Column("Contry", Order = 2)]
        public string Contry { get; set; }

        [Required]
        [StringLength(256)]
        [Column("State", Order = 3)]
        public string State { get; set; }

        [Required]
        [StringLength(256)]
        [Column("City", Order = 4)]
        public string City { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Address1", Order = 5)]
        public string Address1 { get; set; }

        [StringLength(1024)]
        [Column("Address2", Order = 6)]
        public string Address2 { get; set; }

        [StringLength(32)]
        [Column("PostCode", Order = 7)]
        public string PostCode { get; set; }

        //[ForeignKey("DogId")]
        //public virtual Dog Dog { get; set; }
    }
}
