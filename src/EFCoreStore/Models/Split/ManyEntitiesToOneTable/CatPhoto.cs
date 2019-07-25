using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    //[Table("Cat")]
    public class CatPhoto
    {
        //public PersonPhoto()
        //{ 
        //}

        //[Key]
        [Column(Order = 1)]
        public int CatId { get; set; }

        [Column(Order = 2)]
        public DateTime Birth { get; set; }

        [Column(Order = 3)]
        [MaxLength(2000)]
        public byte[] Photo { get; set; }

        [ForeignKey("CatId")]
        public Cat Person { get; set; }
    }
}
