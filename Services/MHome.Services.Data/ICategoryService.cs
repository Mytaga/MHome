using MHome.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MHome.Services.Data
{
    public interface ICategoryService
    {
        IQueryable<Category> All();

        bool ExistById(int id);

        Task AddCategory(Category category);

        Category GetById(int id);
    }
}
