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
    [Table("Item")]
    public class Item
    {
        public Item()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SKU { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(1024)]
        public string ImageUrl { get; set; }
    }
}
