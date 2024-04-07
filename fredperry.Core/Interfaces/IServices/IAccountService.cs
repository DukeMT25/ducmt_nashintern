using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<IEnumerable<IdentityUser>> Search(string entry);
    }
}
