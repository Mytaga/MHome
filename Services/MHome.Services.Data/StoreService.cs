using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System;
using System.Linq;

namespace MHome.Services.Data
{
    public class StoreService : IStoreService
    {
        private readonly IDeletableEntityRepository<Store> storeRepo;

        public StoreService(IDeletableEntityRepository<Store> storeRepo)
        {
            this.storeRepo = storeRepo;
        }

        public IQueryable<Store> GetAll()
        {
            return this.storeRepo.All();
        }
    }
}
