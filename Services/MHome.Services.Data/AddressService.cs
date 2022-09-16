using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class AddressService : IAddressService
    {
        private readonly IDeletableEntityRepository<Address> addressRepo;

        public AddressService(IDeletableEntityRepository<Address> addressRepo)
        {
            this.addressRepo = addressRepo;
        }

        public async Task AddAddress(Address address)
        {
            await this.addressRepo.AddAsync(address);
            await this.addressRepo.SaveChangesAsync();
        }

        public Address GetById(string id)
        {
            return this.addressRepo
               .All()
               .FirstOrDefault(f => f.Id == id);
        }

        public async Task<Address> GetByIdАsync(string id)
        {
            return await this.addressRepo
             .All()
             .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
