using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreStore.Models
{
    [Table("Order")]
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("OrderId", Order = 1)]
        public int OrderId { get; set; }

        [DataType(DataType.DateTime)]
        [Column("OrderDate", Order = 2)]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(160)]
        [Column("CustomerName", Order = 3)]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(24)]
        [Column("Phone", Order = 4)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
        [Display(Name = "Email Address")]
        [Column("Email", Order = 5)]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Display(Name = "Total")]
        [Column("Total", Order = 5, TypeName = "money")]
        public decimal Total
        {
            get
            {
                return OrderDetails.Sum(od => od.Quantity * od.UnitPrice);
            }
        }

        //[ForeignKey("BillingAddressId")]
        [Column("BillingAddressId", Order = 6)]
        public int BillingAddressId { get; set; }

        public virtual Address BillingAddress { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}