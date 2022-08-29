using MHome.Data.Common.Repositories;
using MHome.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IQueryable<Category> All()
        {
            return this.categoryRepo.AllAsNoTracking();
        }

        public bool ExistById(int id)
        {
            return this.categoryRepo
                .AllAsNoTracking()
                .FirstOrDefault(c => c.Id == id) != null;
        }

        public async Task AddCategory(Category category)
        {
            await this.categoryRepo.AddAsync(category);
            await this.categoryRepo.SaveChangesAsync();
        }
    }
}
