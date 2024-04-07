using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ProductViewModel>> Search(string searchTerm)
        {
            // Query the database to find products that match the searchTerm
            var products = await _dbContext.Products
                .Where(p => EF.Functions.Like(p.Code, $"%{searchTerm}%") || EF.Functions.Like(p.Name, $"%{searchTerm}%"))
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    IsNewRelease = p.IsNewRelease,
                })
                .ToListAsync();

            return products;
        }
    }
}
