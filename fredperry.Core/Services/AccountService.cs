using fredperry.Core.Interfaces.IRepositories;
using fredperry.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Services
{
   public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<IdentityUser>> Search(string entry)
        {
            return await _accountRepository.Search(entry);
        }
    }
}
