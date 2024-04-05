using fredperry.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Interfaces.IRepositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetCategoriesByProductId(int productId);
        Task<IEnumerable<ProductCategory>> GetProductsByCategoryId(int productId);

        Task<List<int>> GetCategoryIdsByProductId(int productId);

        Task AddProductCategory(int productId, int categoryId);

        Task UpdateProductCategories(int productId, List<int> categoryIds);

        Task DeleteProductCategoriesByProductId(int productId);
        Task DeleteProductandCategoryByIds(int productId, int categoryId);
    }

}
