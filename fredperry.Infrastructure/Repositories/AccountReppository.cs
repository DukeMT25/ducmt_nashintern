using fredperry.Core.Entities.Business;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IdentityUser>> Search(string query)
        {
            var users = _dbContext.Users
                .Where(u => u.UserName.Contains(query) || u.Email.Contains(query))
                .ToList(); // Convert IQueryable to List synchronously

            return users;
        }

    }

}
