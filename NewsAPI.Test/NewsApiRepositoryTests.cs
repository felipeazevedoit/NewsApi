using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using NewsAPI.Repository.Implementation.Integrations.NewsAPI;
using Newtonsoft.Json;

namespace NewsAPI.Test
{
    [TestClass]
    public class NewsApiRepositoryTests
    {
        [TestMethod]
        public async Task BuscarTodasNoticias_ShouldReturnNewsApiResponse()
        {
            // Arrange

            var newsApiRepository = new NewsApiRepository();

            // Act
            var result = await newsApiRepository.BuscarTodasNoticias();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Status);
           
        }
    }
}
