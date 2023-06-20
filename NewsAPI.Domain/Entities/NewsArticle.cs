using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Domain.Entities
{
    public class NewsArticle : Base
    {
        public Source Source { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Url]
        public string UrlToImage { get; set; }

        [Required]
        public DateTime PublishedAt { get; set; }

        public string Content { get; set; }

        public Category Category { get; set; }

        public NewsArticle()
        {
        }

        public NewsArticle(Source source, string author, string title, string url,string urlToImage, DateTime publishedAt, string content, Category category)
        {
            Source = source;
            Author = author;
            Title = title;
            Url = url;
            UrlToImage = urlToImage;
            PublishedAt = publishedAt;
            Content = content;
            Category = category;
            CreationDate = DateTime.Now;
            Active = true;
        }
    }
}
