using MVCHomework6.Data.Database;

namespace MVCHomework6.Service
{
    public class DataService : IDataService
    {
        private readonly BlogDbContext _context;

        public DataService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Articles>> GetArticlesAsync(string filter)
        {
            var model = _context.Articles.Where(x => string.IsNullOrEmpty(filter) ? true : (x.Title.Contains(filter) || x.Body.Contains(filter)));

            return await Task.FromResult(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
