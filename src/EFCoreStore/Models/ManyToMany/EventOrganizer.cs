using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("EventOrganizer")]
    public class EventOrganizer
    {
        //[Key]
        [Column("OrganizerId", Order = 1)]
        public int OrganizerId { get; set; }

        //[Key]
        [Column("EventId", Order = 2)]
        public int EventId { get; set; }

        //[ForeignKey("OrganizerId")]
        public virtual Organizer Organizer { get; set; }

        //[ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}
