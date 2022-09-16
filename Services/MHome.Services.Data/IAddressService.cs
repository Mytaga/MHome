using MHome.Data.Models;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface IAddressService
    {
        Task<Address> GetByIdАsync(string id);

        Address GetById(string id);

        Task AddAddress(Address address);
    }
}
