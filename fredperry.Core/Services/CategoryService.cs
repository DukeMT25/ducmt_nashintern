using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IMapper;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseMapper<Category, CategoryViewModel> _categoryViewModelMapper;
        private readonly IBaseMapper<CategoryViewModel, Category> _categoryMapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            IBaseMapper<Category, CategoryViewModel> categoryViewModelMapper,
            IBaseMapper<CategoryViewModel, Category> categoryMapper,
            ICategoryRepository categoryRepository)
        {
            _categoryMapper = categoryMapper;
            _categoryViewModelMapper = categoryViewModelMapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return _categoryViewModelMapper.MapList(await _categoryRepository.GetAll());
        }

        public async Task<PaginatedDataViewModel<CategoryViewModel>> GetPaginatedCategories(int pageNumber, int pageSize)
        {
            //Get peginated data
            var paginatedData = await _categoryRepository.GetPaginatedData(pageNumber, pageSize);

            //Map data with ViewModel
            var mappedData = _categoryViewModelMapper.MapList(paginatedData.Data);

            var paginatedDataViewModel = new PaginatedDataViewModel<CategoryViewModel>(mappedData.ToList(), paginatedData.TotalCount);

            return paginatedDataViewModel;
        }

        public async Task<CategoryViewModel> GetCategory(int id)
        {
            return _categoryViewModelMapper.MapModel(await _categoryRepository.GetById(id));
        }

        public async Task<bool> IsExists(string key, string value)
        {
            return await _categoryRepository.IsExists(key, value);
        }

        public async Task<bool> IsExistsForUpdate(int id, string key, string value)
        {
            return await _categoryRepository.IsExistsForUpdate(id, key, value);
        }

        public async Task<CategoryViewModel> Create(CategoryViewModel model)
        {
            //Mapping through AutoMapper
            var entity = _categoryMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;

            return _categoryViewModelMapper.MapModel(await _categoryRepository.Create(entity));
        }

        public async Task Update(CategoryViewModel model)
        {
            var existingData = await _categoryRepository.GetById(model.Id);

            //Manual mapping
            existingData.Name = model.Name;
            existingData.UpdateDate = DateTime.Now;

            await _categoryRepository.Update(existingData);
        }

        public async Task Delete(int id)
        {
            var entity = await _categoryRepository.GetById(id);
            await _categoryRepository.Delete(entity);
        }

        public async Task<IEnumerable<CategoryViewModel>> Search(string searchTerm)
        {
            var categories = await _categoryRepository.Search(searchTerm);
            return categories;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesByIds(IEnumerable<int> categoryIds)
        {
            var categories = new List<CategoryViewModel>();
            foreach (var categoryId in categoryIds)
            {
                var category = await GetCategory(categoryId);
                categories.Add(category);
            }
            return categories;
        }

    }
}
