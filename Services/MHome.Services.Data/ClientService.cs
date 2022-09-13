using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> clientRepo;

        public ClientService(IDeletableEntityRepository<ApplicationUser> clientRepo)
        {
            this.clientRepo = clientRepo;
        }

        public ApplicationUser GetById(string id)
        {
            return this.clientRepo
              .All()
              .FirstOrDefault(f => f.Id == id);
        }

        public async Task<ApplicationUser> GetByIdАsync(string id)
        {
            return await this.clientRepo
               .All()
               .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
