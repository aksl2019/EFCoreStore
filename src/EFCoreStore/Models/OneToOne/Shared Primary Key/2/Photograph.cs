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
    [Table("Photograph")]
    public class Photograph
    {
        public Photograph()
        {
        }

        [Key]
        public int PhotoId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Title { get; set; }

        [MaxLength(10000)]
        public byte[] ThumbnailBits { get; set; }

        public virtual PhotographFullImage PhotographFullImage { get; set; }
    }
}
