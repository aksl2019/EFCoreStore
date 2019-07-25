using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

//http://www.cnblogs.com/VolcanoCloud/p/4527549.html

namespace EFCoreStore.Models
{
    //自引用的多对多关系
    public class Product
    {
        public Product()
        {
            this.RelatedProducts = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [ForeignKey("RelatedProductId")]
        public int RelatedProductId { get; set; }

        public Product RelatedProduct { get; set; }

        [ForeignKey("OtherRelatedProductId")]
        public int OtherRelatedProductId { get; set; }
        
        public Product OtherRelatedProduct { get; set; }

        //自己(本product)的关联Products
        [InverseProperty("RelatedProduct")]
        public virtual ICollection<Product> RelatedProducts { get; set; }

        ////与自己(本product)关联的Products
        [InverseProperty("OtherRelatedProduct")]
        public virtual ICollection<Product> OtherRelatedProducts { get; set; }
    }
}
