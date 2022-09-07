using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class OrderService : IOrderService
    {
        private const string EmptyString = "";
        private readonly IDeletableEntityRepository<Order> orderRepo;

        public OrderService(IDeletableEntityRepository<Order> orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public async Task AddOrder(Order order)
        {
            await this.orderRepo.AddAsync(order);
            await this.orderRepo.SaveChangesAsync();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAllByName(string searchName = EmptyString)
        {
            if (searchName != null)
            {
                return this.orderRepo
                    .AllAsNoTracking()
                    .Where(f => $"{f.Client.FirstName + f.Client.LastName}".ToLower().Contains(searchName.ToLower()));
            }

            return this.orderRepo.All();
        }

        public Order GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdАsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
