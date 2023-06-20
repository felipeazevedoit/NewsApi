using NewsAPI.Aplication.Helper;
using NewsAPI.Aplication.Interfaces;
using NewsAPI.Domain.Entities;
using NewsAPI.Domain.Interfaces;

namespace NewsAPI.Aplication.Services
{
    public class CategoryApp : ICategoryApp
    {
        private readonly ICategory _rep;
        private readonly LogHelper _logHelper;

        public CategoryApp(ICategory rep, LogHelper logHelper)
            => (_rep, _logHelper) = (rep ?? throw new ArgumentNullException(nameof(rep)), logHelper ?? throw new ArgumentNullException(nameof(logHelper)));

        public async Task<Category> GetCategory(Category category)
        {
            try
            {
                return _rep.GetCategory(category);
            }
            catch (Exception ex)
            {
                LogAndReturnNull(ex, nameof(GetCategory));
                return null;
            }
        }

        public async Task<bool> InactivateCategory(Category category)
        {
            try
            {
                _rep.InactivateCategory(category);
                return true;
            }
            catch (Exception ex)
            {
                LogAndReturnNull(ex, nameof(InactivateCategory));
                return false;
            }
        }

        public async Task<Category> RegisterCategory(Category category)
        {
            try
            {
                return  _rep.RegisterCategory(category);
            }
            catch (Exception ex)
            {
                LogAndReturnNull(ex, nameof(RegisterCategory));
                return null;
            }
        }

      
        private void LogAndReturnNull(Exception ex, string methodName)
            => _logHelper.LogError($"Error in {methodName}: {ex.Message}");
    }
}
