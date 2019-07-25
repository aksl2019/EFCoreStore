using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//http://ef.readthedocs.io/en/latest/modeling/relationships.html#one-to-one

namespace EFCoreStore.Models
{
    //One to one
    [Table("Blog")]
    public class Blog
    {
        public Blog()
        {
        }

        [Key]
        public int BlogId { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string Url { get; set; }

        //[NotMapped]
        public DateTime LoadedFromDatabase { get; set; }

        public virtual BlogImage BlogImage { get; set; }
    }
}
