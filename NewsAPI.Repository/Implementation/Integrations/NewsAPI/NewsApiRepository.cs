using Newtonsoft.Json;
using Polly;

namespace NewsAPI.Repository.Implementation.Integrations.NewsAPI
{
    public class NewsApiRepository
    {
        public async Task<NewsApiResponse> BuscarTodasNoticias()
        {
            string apiKey = "7a16497674324825a425a2c75178f711";
            string apiUrl = $"https://newsapi.org/v2/everything?q=&apiKey={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NewsApiResponse>(jsonResponse);
            }
        }
    }
}
