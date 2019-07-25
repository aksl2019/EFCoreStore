using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//http://www.cnblogs.com/Gyoung/archive/2013/01/25/2874589.html

namespace EFCoreStore.Models
{
    //多个实体映射到一张表
    //[Table("Cat")]
    public class Cat
    {
        //public Person()
        //{ 
        //}

        [Key]
        public int CatId { get; set; }

        [Required]
        [StringLength(256)]
        [Column("Name", Order = 2)]
        public string Name { get; set; }

        public bool Sex { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public CatPhoto Photo { get; set; }
    }
}
