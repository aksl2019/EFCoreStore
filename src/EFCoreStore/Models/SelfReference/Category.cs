using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    //自引用的一对多关系
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<Category>();
        }

        [Key]
        [Column("CategoryId", Order = 1)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Name", Order = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Path", Order = 3)]
        public string Path { get; set; }

        [Column("ParentId", Order = 4)]
        public int? ParentId { get; set; }

        //[ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }
    }
}
