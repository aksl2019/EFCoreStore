using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreStore.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column("OrderDetailId", Order = 1)]
        public int OrderDetailId { get; set; }

        [Required]
        [Column("Quantity", Order = 2)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("UnitPrice", Order = 3, TypeName = "money")]
        public decimal UnitPrice { get; set; }

        //public int OrderId { get; set; }

        //public virtual Order Order { get; set; }
    }
}