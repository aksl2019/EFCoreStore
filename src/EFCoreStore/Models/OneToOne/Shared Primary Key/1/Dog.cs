using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//https://weblogs.asp.net/scottgu/entity-framework-4-code-first-custom-database-schema-mapping
//http://www.cnblogs.com/Gyoung/archive/2013/01/25/2874589.html

//共享主键，多个实体映射到一张表

namespace EFCoreStore.Models
{
    [Table("Dog")]
    public class Dog
    {
        [Key]
        [Column("DogId", Order = 1)]
        public int DogId { get; set; }

        [Required]
        [StringLength(256)]
        [Column("Name", Order = 2)]
        public string Name { get; set; }

        public virtual DogAddress Address { get; set; }
    }
}
