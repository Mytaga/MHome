using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Client> clientRepo;

        public Client GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdАsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
