using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(256)]
        public string Name { get; set; }

        public int? StoreId { get; set; }

        //[ForeignKey("StoreId")]
        public virtual Store Store { get; set; }
    }
}
