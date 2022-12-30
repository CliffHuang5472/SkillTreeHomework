using Microsoft.AspNetCore.Mvc;
using MVCHomework6.Models;
using System.Diagnostics;
using MVCHomework6.Data;
using MVCHomework6.Data.Database;
using MVCHomework6.Service;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCHomework6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _context;
        private readonly IHtmlHelper _htmlHelper;

        public HomeController(ILogger<HomeController> logger, BlogDbContext context, IHtmlHelper htmlHelper)
        {
            _logger = logger;
            _context = context;
            _htmlHelper = htmlHelper;
        }

        public IActionResult Index(int? page, string content)
        {
            //PartiewView用
            //var model = _context.Articles.ToList();
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(model.ToPagedList(pageNumber, pageSize));

            ViewBag.CurrentPage = page ?? 1;
            ViewBag.CurrentFilter = content;

            return View();
        }

        [HttpPost]
        public IActionResult getArticle(string content)
        {
            return ViewComponent("Article", new { content = content });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}