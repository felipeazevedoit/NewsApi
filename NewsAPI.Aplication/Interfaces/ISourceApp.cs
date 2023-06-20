using NewsAPI.Domain.Entities;

namespace NewsAPI.Aplication.Interfaces
{
    public interface ISourceApp
    {
        public Task<Source> RegisterSource(Source fonte);
        public Task<Source> GetSource(Source fonte);
        public Task<bool> InactivateSource(Source fonte);
    }
}
