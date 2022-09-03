using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Order> orderRepo;

        public OrderService(IDeletableEntityRepository<Order> orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public Task AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> All()
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
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
