using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Aplication.Interfaces;
using NewsAPI.Domain.Entities;

namespace NewsApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly INewsArticleApp _App;

        public NewsController(INewsArticleApp iNewsArticleApp)
        {
            _App = iNewsArticleApp;
        }


        [HttpGet("news")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetAllNews()
        {
             var _news = await _App.GetAll();

             if(_news.Any()) return NotFound();
                
            return Ok(_news);
        }

        [HttpGet("news/{id}")]
        public async Task<ActionResult<NewsArticle>> GetNewsById(Guid id)
        {
            var news = await _App.GetById(id);

            if (news == null) return NotFound();

            return Ok(news);
        }

        [HttpGet("news/category/{category}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsByCategory(Category category)
        {
            var news = await _App.GetNewsArticlebyCategory(category);

            if (!news.Any()) return NotFound();

            return Ok(news);
        }

        [HttpGet("news/source/{source}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsBySource(string source)
        {
            var news = await _App.GetNewsArticlebySource(source); 

            if (!news.Any()) return NotFound();

            return Ok(news);
        }

        [HttpGet("news/search/{keyword}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> SearchNewsByKeyword(string keyword)
        {
            var news = await _App.GetNewsArticlebykeyword(keyword);

            if (!news.Any()) return NotFound();
            
            return Ok(news);
        }
    }

  
}

