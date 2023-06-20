using NewsAPI.Domain.Entities;

namespace NewsAPI.Domain.Interfaces
{
    public interface INewsArticle
    {
        public  Task<List<NewsArticle>> RegisterNews(List<NewsArticle> NewsArticles);
        public  Task<List<NewsArticle>> GetAll();
        public  Task<NewsArticle> GetById(Guid id);
        public  Task<List<NewsArticle>> GetNewsArticlebyCategory(Category categoria);
        public  Task<List<NewsArticle>> GetNewsArticlebySource(string source);
        public  Task<List<NewsArticle>> GetNewsArticlebykeyword(string keyword);
    }
}
