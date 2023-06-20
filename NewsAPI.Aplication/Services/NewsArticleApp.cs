using NewsAPI.Aplication.Interfaces;
using NewsAPI.Domain.Entities;
using NewsAPI.Domain.Interfaces;

namespace NewsAPI.Aplication.Services
{


    public class NewsArticleApp : INewsArticleApp
    {
        private readonly INewsArticle _rep;

        public async Task<List<NewsArticle>> RegisterNews(List<NewsArticle> newsArticles)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar notícias: {ex.Message}");
                throw;
            }
        }

        public async Task<List<NewsArticle>> GetAll()
        {
            try
            {
                var mews = await _rep.GetAll();
                if (mews == null) return null;
            
                return mews;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<NewsArticle> GetById(Guid id)
        {
            try
            {
                var news = await _rep.GetById(id);
                if (news == null) return null;

                return news;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<NewsArticle>> GetNewsArticlebyCategory(Category category)
        {
            try
            {
                var news = await _rep.GetNewsArticlebyCategory(category);
                if (news == null) return null;

                return news;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<NewsArticle>> GetNewsArticlebykeyword(string keyword)
        {
            try
            {
                var news = await _rep.GetNewsArticlebykeyword(keyword);
                if (news == null) return null;

                return news;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar notícias pela fonte: {ex.Message}");
                return null;
            }
        }

        public async Task<List<NewsArticle>> GetNewsArticlebySource(string source)
        {
            try
            {
                var news = await _rep.GetNewsArticlebySource(source);
                if (news == null) return null;

                return news;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
