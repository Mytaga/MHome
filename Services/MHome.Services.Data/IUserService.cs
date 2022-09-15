using MHome.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IUserService
    {
        Task<ApplicationUser> GetByIdАsync(string id);

        ApplicationUser GetById(string id);
    }
}
