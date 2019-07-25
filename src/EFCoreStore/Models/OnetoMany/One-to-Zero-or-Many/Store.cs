using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("Store")]
    public class Store
    {
        public Store()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        [Column(Order = 1)]
        public int StoreId { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
