using NewsAPI.Aplication.Helper;
using NewsAPI.Aplication.Interfaces;
using NewsAPI.Domain.Entities;
using NewsAPI.Domain.Interfaces;
using NewsAPI.Repository.Interfaces;

namespace NewsAPI.Aplication.Services
{
    public class SourceApp : ISourceApp
    {
        private readonly ISourceRepository _rep;
        private readonly LogHelper _logHelper;

        public SourceApp(INewsArticle rep, LogHelper logHelper)
        {
            _rep = (ISourceRepository?)(rep ?? throw new ArgumentNullException(nameof(rep)));
            _logHelper = logHelper ?? throw new ArgumentNullException(nameof(logHelper));
        }

        public async Task<Source> RegisterSource(Source source) => _rep.RegisterSource(source);

        public async Task<Source> GetSource(Source source) =>  _rep.GetSource(source);

        public async Task<bool> InactivateSource(Source source) =>   _rep.InactivateSource(source);

      
        private void LogAndReturnNull(Exception ex) => _logHelper.LogError($"Error: {ex.Message}");
    }
}
