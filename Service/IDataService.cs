using MVCHomework6.Data.Database;

namespace MVCHomework6.Service
{
    public interface IDataService
    {
        Task<IEnumerable<Articles>> GetArticlesAsync(string filter);
        Task SaveAsync();
    }
}
