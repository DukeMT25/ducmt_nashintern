﻿using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IMapper;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseMapper<Product, ProductViewModel> _productViewModelMapper;
        private readonly IBaseMapper<ProductViewModel, Product> _productMapper;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IBaseMapper<Product, ProductViewModel> productViewModelMapper,
            IBaseMapper<ProductViewModel, Product> productMapper,
            IProductRepository productRepository)
        {
            _productMapper = productMapper;
            _productViewModelMapper = productViewModelMapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return _productViewModelMapper.MapList(await _productRepository.GetAll());
        }

        public async Task<PaginatedDataViewModel<ProductViewModel>> GetPaginatedProducts(int pageNumber, int pageSize)
        {
            //Get peginated data
            var paginatedData = await _productRepository.GetPaginatedData(pageNumber, pageSize);

            //Map data with ViewModel
            var mappedData = _productViewModelMapper.MapList(paginatedData.Data);

            var paginatedDataViewModel = new PaginatedDataViewModel<ProductViewModel>(mappedData.ToList(), paginatedData.TotalCount);

            return paginatedDataViewModel;
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            return _productViewModelMapper.MapModel(await _productRepository.GetById(id));
        }

        public async Task<bool> IsExists(string key, string value)
        {
            return await _productRepository.IsExists(key, value);
        }

        public async Task<bool> IsExistsForUpdate(int id, string key, string value)
        {
            return await _productRepository.IsExistsForUpdate(id, key, value);
        }

        public async Task<ProductViewModel> Create(ProductViewModel model)
        {
            //Mapping through AutoMapper
            var entity = _productMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;

            return _productViewModelMapper.MapModel(await _productRepository.Create(entity));
        }

        public async Task Update(ProductViewModel model)
        {
            var existingData = await _productRepository.GetById(model.Id);

            //Manual mapping
            existingData.Code = model.Code;
            existingData.Name = model.Name;
            existingData.Price = model.Price;
            existingData.Description = model.Description;
            existingData.IsActive = model.IsActive;
            existingData.UpdateDate = DateTime.Now;

            await _productRepository.Update(existingData);
        }

        public async Task Delete(int id)
        {
            var entity = await _productRepository.GetById(id);
            await _productRepository.Delete(entity);
        }

        public async Task<IEnumerable<ProductViewModel>> Search(string searchTerm)
        {
            // Implement the logic to search for products based on the given search term
            var searchResults = await _productRepository.Search(searchTerm);

            return searchResults;
        }


        public async Task<IEnumerable<ProductViewModel>> GetProductsByIds(IEnumerable<int> productIds)
        {
            var products = new List<ProductViewModel>();
            foreach (var productId in productIds)
            {
                var product = await GetProduct(productId);
                products.Add(product);
            }
            return products;
        }
    }
}
