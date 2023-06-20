using ewsAPI.Repository.Contexts;
using NewsAPI.Domain.Entities;
using NewsAPI.Repository.Interfaces;

namespace NewsAPI.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Category RegisterCategory(Category category)
        {
            dbContext.Category.Add(category);
            dbContext.SaveChanges();
            return category;
        }

        public bool InactivateCategory(Category category)
        {
            category.Active = false;
            dbContext.SaveChanges();
            return true;
        }

        public Category GetCategory(Category category)
        {
            return dbContext.Category.FirstOrDefault(c => c.Id == category.Id);
        }
    }
}
