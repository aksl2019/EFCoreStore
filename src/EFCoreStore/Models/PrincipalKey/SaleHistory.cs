using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace EFCoreStore.Models
{
    //多个实体映射到一张表
    [Table("SaleHistory")]
    public class SaleHistory
    {
        public SaleHistory()
        {
        }

        [Key]
        public int SaleHistoryId { get; set; }

        public DateTime DateSold { get; set; }

        public decimal Price { get; set; }

        public string LicensePlate { get; set; }

        public Bus Bus { get; set; }
    }
}
