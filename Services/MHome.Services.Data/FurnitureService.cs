using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class FurnitureService : IFurnitureService
    {
        private const string EmptyString = "";
        private readonly IDeletableEntityRepository<Furniture> furnitureRepo;

        public FurnitureService(IDeletableEntityRepository<Furniture> furnitureRepo)
        {
            this.furnitureRepo = furnitureRepo;
        }

        public IQueryable<Furniture> GetAllByName(string searchName = EmptyString)
        {
            if (searchName != null)
            {
                return this.furnitureRepo
                    .AllAsNoTracking()
                    .Where(f => f.Name.ToLower().Contains(searchName.ToLower()));
            }

            return this.furnitureRepo.All();
        }

        public IQueryable<Furniture> GetAllByCategory(string categoryName = EmptyString)
        {
            if (categoryName != EmptyString)
            {
                return this.furnitureRepo
                    .AllAsNoTracking()
                    .Where(f => f.Category.Name.ToLower().Contains(categoryName.ToLower()));
            }

            return this.furnitureRepo.All();
        }

        public ICollection<string> GetAllFurnitureCategories()
        {
            return this.furnitureRepo
                .AllAsNoTracking()
                .Select(f => f.Category.Name)
                .Distinct()
                .ToArray();
        }

        public async Task AddFurniture(Furniture furniture)
        {
            await this.furnitureRepo.AddAsync(furniture);
            await this.furnitureRepo.SaveChangesAsync();
        }

        public void DeleteFurniture(Furniture furniture)
        {
            this.furnitureRepo.Delete(furniture);
            this.furnitureRepo.SaveChanges();
        }

        public Furniture GetById(string id)
        {
            return this.furnitureRepo
               .All()
               .FirstOrDefault(f => f.Id == id);
        }

        public async Task<Furniture> GetByIdАsync(string id)
        {
            return await this.furnitureRepo
                .All()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void EditFurniture(Furniture furniture)
        {
            this.furnitureRepo.Update(furniture);
            this.furnitureRepo.SaveChanges();
        }
    }
}