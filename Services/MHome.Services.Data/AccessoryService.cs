using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class AccessoryService : IAccessoryService
    {
        private const string EmptyString = "";
        private readonly IDeletableEntityRepository<Accessory> accessoryRepo;

        public AccessoryService(IDeletableEntityRepository<Accessory> accessoryRepo)
        {
            this.accessoryRepo = accessoryRepo;
        }

        public async Task AddAccessory(Accessory accessory)
        {
            await this.accessoryRepo.AddAsync(accessory);
            await this.accessoryRepo.SaveChangesAsync();
        }

        public void DeleteAccesory(Accessory accessory)
        {
            this.accessoryRepo.Delete(accessory);
            this.accessoryRepo.SaveChanges();
        }

        public void EditAccessory(Accessory accessory)
        {
            this.accessoryRepo.Update(accessory);
            this.accessoryRepo.SaveChanges();
        }

        public IQueryable<Accessory> GetAllByName(string searchName = "")
        {
            if (searchName != null)
            {
                return this.accessoryRepo
                    .AllAsNoTracking()
                    .Where(f => f.Name.ToLower().Contains(searchName.ToLower()));
            }

            return this.accessoryRepo.All();
        }

        public Accessory GetById(string id)
        {
            return this.accessoryRepo
              .All()
              .FirstOrDefault(f => f.Id == id);
        }

        public async Task<Accessory> GetByIdАsync(string id)
        {
            return await this.accessoryRepo
               .All()
               .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}