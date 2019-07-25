using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//http://www.cnblogs.com/VolcanoCloud/p/4527549.html
//http://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx

namespace EFCoreStore.Models
{
    public class Event
    {
        public Event()
        {
            this.EventOrganizers = new HashSet<EventOrganizer>();
        }

        [Key]
        [Column("EventId", Order = 1)]
        public int EventId { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Name", Order = 2)]
        public string Name { get; set; }

        public virtual ICollection<EventOrganizer> EventOrganizers { get; set; }
    }
}
