using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class StoreService : IStoreService
    {
        private readonly IDeletableEntityRepository<Store> storeRepo;

        public StoreService(IDeletableEntityRepository<Store> storeRepo)
        {
            this.storeRepo = storeRepo;
        }

        public async Task AddStore(Store store)
        {
            await this.storeRepo.AddAsync(store);
            await this.storeRepo.SaveChangesAsync();
        }

        public IQueryable<Store> GetAll()
        {
            return this.storeRepo.All();
        }
    }
}
