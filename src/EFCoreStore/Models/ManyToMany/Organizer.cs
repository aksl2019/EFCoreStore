using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("Organizer")]
    public class Organizer
    {
        public Organizer()
        {
            this.EventOrganizers = new HashSet<EventOrganizer>();
        }

        [Key]
        [Column("OrganizerId", Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizerId { get; set; }

        [Required]
        [StringLength(1024)]
        [Column("Name", Order = 2)]
        public string Name { get; set; }

        public virtual ICollection<EventOrganizer> EventOrganizers { get; set; }
    }
}
