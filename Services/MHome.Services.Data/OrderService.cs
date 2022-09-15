using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
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
            this.orderRepo.Delete(order);
            this.orderRepo.SaveChanges();
        }

        public IQueryable<Order> GetAllByName(string searchName = EmptyString)
        {
            if (searchName != null)
            {
                return this.orderRepo
                    .AllAsNoTracking()
                    .Where(f => f.User.FirstName.ToLower().Contains(searchName.ToLower()));
            }

            return this.orderRepo.All();
        }

        public Order GetById(string id)
        {
            return this.orderRepo
                .All()
                .FirstOrDefault(o => o.Id == id);
        }

        public async Task<Order> GetByIdАsync(string id)
        {
            return await this.orderRepo
                 .All()
                 .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
