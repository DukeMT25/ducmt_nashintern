using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Entities.Business
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }

}
