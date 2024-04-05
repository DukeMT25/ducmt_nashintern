using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Entities.General
{
    [Table("ProductCategories")]
    public class ProductCategory : Base<int>
    {
        // Composite key consisting of productId and categoryId
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
