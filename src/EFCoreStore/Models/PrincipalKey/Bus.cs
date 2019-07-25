using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//http://ef.readthedocs.io/en/latest/modeling/relationships.html#foreignkey

namespace EFCoreStore.Models
{
    [Table("Bus")]
    public class Bus
    {
        public Bus()
        {
            this.SaleHistories = new HashSet<SaleHistory>();
        }

        [Key]
        public int BusId { get; set; }

        public string LicensePlate { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public virtual ICollection<SaleHistory> SaleHistories { get; set; }
    }
}
