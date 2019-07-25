using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("BlogImage")]
    public class BlogImage
    {
        public BlogImage()
        {
        }

        [Key]
        [Column(Order = 1)]
        public int BlogImageId { get; set; }

        [Column(Order = 3)]
        [MaxLength(2000)]
        public byte[] Image { get; set; }

        [Column(Order = 2)]
        [StringLength(1024)]
        public string Caption { get; set; }

        [Column(Order = 4)]
        public int? BlogId { get; set; }

        //[ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
    }
}
