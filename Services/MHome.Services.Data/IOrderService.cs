using MHome.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IOrderService
    {
        IQueryable<Order> GetAllByName(string searchName = "");

        Task<Order> GetByIdАsync(string id);

        Order GetById(string id);

        Task AddOrder(Order order);

        void DeleteOrder(Order order);
    }
}
