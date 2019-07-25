using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//https://weblogs.asp.net/scottgu/entity-framework-4-code-first-custom-database-schema-mapping

namespace EFCoreStore.Models
{
    [Table("Dinner")]
    public class Dinner
    {
        public Dinner()
        {
            Address = new Address();
        }

        [Key]
        [Column("DinnerId", Order = 1)]
        public int DinnerId { get; set; }

        [Required]
        [StringLength(256)]
        [Column("Title", Order = 2)]
        public string Title { get; set; }

        public Address Address { get; set; }
    }
}
