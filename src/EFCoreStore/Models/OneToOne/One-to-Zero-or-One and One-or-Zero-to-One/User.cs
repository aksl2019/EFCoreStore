using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//https://weblogs.asp.net/manavi/associations-in-ef-4-1-code-first-part-3-shared-primary-key-associations

namespace EFCoreStore.Models
{
    //User 1 to  0.1 Address
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        public int? BillingAddressId { get; set; }

        [ForeignKey("BillingAddressId")]
        public virtual Address BillingAddress { get; set; }
    }
}
