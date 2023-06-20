using NewsAPI.Domain.Entities;
using NewsAPI.Domain.Interfaces;

namespace NewsAPI.Aplication.Interfaces
{
    public interface ICategoryApp
    {
        Task<Category> RegisterCategory(Category category);
        Task<Category> GetCategory(Category category);
        Task<bool> InactivateCategory(Category category);
    }
}
