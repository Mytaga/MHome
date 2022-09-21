using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Client> clientRepo;

        public ClientService(IDeletableEntityRepository<Client> clientRepo)
        {
            this.clientRepo = clientRepo;
        }

        public async Task AddClient(Client client)
        {
            await this.clientRepo.AddAsync(client);
            await this.clientRepo.SaveChangesAsync();
        }

        public void EditClient(Client client)
        {
            this.clientRepo.Update(client);
            this.clientRepo.SaveChangesAsync();
        }

        public Client GetById(string id)
        {
            return this.clientRepo.All().FirstOrDefault(c => c.Id == id);
        }

        public async Task<Client> GetByIdАsync(string id)
        {
            return await this.clientRepo.All().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
