using fredperry.Core.Entities.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task<PaginatedDataViewModel<CategoryViewModel>> GetPaginatedCategories(int pageNumber, int pageSize);
        Task<CategoryViewModel> GetCategory(int id);
        Task<bool> IsExists(string key, string value);
        Task<bool> IsExistsForUpdate(int id, string key, string value);
        Task<CategoryViewModel> Create(CategoryViewModel model);
        Task Update(CategoryViewModel model);
        Task Delete(int id);
        Task<IEnumerable<CategoryViewModel>> Search(string searchItem);

        Task<IEnumerable<CategoryViewModel>> GetCategoriesByIds(IEnumerable<int> categoryIds);
    }
}
