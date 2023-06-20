using NewsAPI.Domain.Entities;

namespace NewsAPI.Domain.Interfaces
{
    public interface ICategory
    {
        public Category RegisterCategory(Category category);
        public Category GetCategory(Category category);
        public bool InactivateCategory(Category category);


    }
}
