using AutoMapper;
using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IMapper;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Core.Interfaces.IServices;
using fredperry.Core.Mapper;
using fredperry.Core.Services;
using fredperry.Infrastructure.Repositories;

namespace fredperry.UI.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IAccountService, AccountService>();

            #endregion

            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            #endregion

            #region Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();

                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();

            });

            IMapper mapper = configuration.CreateMapper();

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Product, ProductViewModel>>(new BaseMapper<Product, ProductViewModel>(mapper));
            services.AddSingleton<IBaseMapper<ProductViewModel, Product>>(new BaseMapper<ProductViewModel, Product>(mapper));

            services.AddSingleton<IBaseMapper<Category, CategoryViewModel>>(new BaseMapper<Category, CategoryViewModel>(mapper));
            services.AddSingleton<IBaseMapper<CategoryViewModel, Category>>(new BaseMapper<CategoryViewModel, Category>(mapper));

            #endregion

            return services;
        }
    }
}
