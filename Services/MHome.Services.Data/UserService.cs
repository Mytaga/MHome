using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        public ApplicationUser GetById(string id)
        {
            return this.userRepo
              .All()
              .FirstOrDefault(f => f.Id == id);
        }

        public async Task<ApplicationUser> GetByIdАsync(string id)
        {
            return await this.userRepo
               .All()
               .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
