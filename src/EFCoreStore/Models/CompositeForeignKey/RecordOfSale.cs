using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace EFCoreStore.Models
{
    //多个实体映射到一张表
    [Table("RecordOfSale")]
    public class RecordOfSale
    {
        public RecordOfSale()
        {
        }

        [Key]
        public int RecordOfSaleId { get; set; }

        public DateTime DateSold { get; set; }

        public decimal Price { get; set; }

        public string CarState { get; set; }

        public string CarLicensePlate { get; set; }

        public Car Car { get; set; }
    }
}
