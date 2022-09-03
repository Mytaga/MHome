using MHome.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IOrderService
    {
        ICollection<Order> All();

        Task<Order> GetByIdАsync(string id);

        Order GetById(string id);

        Task AddOrder(Order order);

        void DeleteOrder(Order order);
    }
}
