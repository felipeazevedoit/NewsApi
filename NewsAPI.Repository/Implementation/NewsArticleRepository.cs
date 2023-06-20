using ewsAPI.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Domain.Entities;
using NewsAPI.Repository.Interfaces;

namespace NewsAPI.Repository.Implementation
{

    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly ApplicationDbContext context;

        public NewsArticleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<NewsArticle>> RegisterNews(List<NewsArticle> newsArticles)
        {
            try
            {
                await context.NewsArticle.AddRangeAsync(newsArticles);
                await context.SaveChangesAsync();
                return newsArticles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NewsArticle>> GetAll()
        {
            try
            {
                return await context.NewsArticle.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<NewsArticle> GetById(Guid id)
        {
            try
            {
                return await context.NewsArticle.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NewsArticle>> GetNewsArticlebyCategory(Category category)
        {
            try
            {
                return await context.NewsArticle
                    .Where(n => n.Category == category)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<NewsArticle>> GetNewsArticlebySource(string source)
        {
            try
            {
                return await context.NewsArticle
                    .Where(n => n.Source.Name == source)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar notícias pela fonte: {ex.Message}");
                throw;
            }
        }

        public async Task<List<NewsArticle>> GetNewsArticlebykeyword(string keyword)
        {
            try
            {
                return await context.NewsArticle
                    .Where(n => n.Title.Contains(keyword) || n.Description.Contains(keyword) || n.Content.Contains(keyword))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar notícias por palavra-chave: {ex.Message}");
                throw;
            }
        }
    }
}
