using System.Threading.Tasks;
using BookFast.Contracts;
using Microsoft.AspNet.Mvc;

namespace BookFast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService searchService;

        public HomeController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchText, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return View("NoSearchResults");

            var result = await searchService.SearchAsync(searchText, page);
            if (result == null)
                return View("NoSearchResults");

            ViewBag.SearchText = searchText;
            ViewBag.Page = page;
            return View(result);
        }
    }
}
