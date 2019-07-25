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
    [Table("PhotographFullImage")]
    public class PhotographFullImage
    {
        public PhotographFullImage()
        {
        }

        //[Key]
        public int PhotoId { get; set; }

        [MaxLength(20000)]
        public byte[] HighResolutionBits { get; set; }

        //[ForeignKey("PhotoId")]
        //public virtual Photograph Photograph { get; set; }
    }
}
