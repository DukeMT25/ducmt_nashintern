using fredperry.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Entities.Business
{
    public class CategoryDeleteConfirmationViewModel
    {
        public CategoryViewModel Category { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<ProductViewModel>? Products { get; set; }
    }
}
