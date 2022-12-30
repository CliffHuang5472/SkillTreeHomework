using Microsoft.AspNetCore.Mvc;
using MVCHomework6.Service;
using X.PagedList;

namespace MVCHomework6.ViewComponents
{
    public class ArticleViewComponent : ViewComponent
    {
        private IDataService _dataService;

        public ArticleViewComponent(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? page, string content)
        {
            var model = await _dataService.GetArticlesAsync(content);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public async Task<IViewComponentResult> OnPostSearchAsync(int? page, string content)
        {
            var model = await _dataService.GetArticlesAsync(content);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}
