using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<IdentityUser>> Search(string query);
    }
}
