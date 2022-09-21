using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class ClientCardService : IClientCardService
    {
        private readonly IDeletableEntityRepository<ClientCard> clientCardRepo;

        public ClientCardService(IDeletableEntityRepository<ClientCard> clientCardRepo)
        {
            this.clientCardRepo = clientCardRepo;
        }

        public async Task AddClientCard(ClientCard clientCard)
        {
            await this.clientCardRepo.AddAsync(clientCard);
            await this.clientCardRepo.SaveChangesAsync();
        }

        public ClientCard GetById(string id)
        {
            return this.clientCardRepo.All().FirstOrDefault(cc => cc.Id == id);
        }

        public async Task<ClientCard> GetByIdАsync(string id)
        {
            return await this.clientCardRepo.All().FirstOrDefaultAsync(cc => cc.Id == id);
        }
    }
}
