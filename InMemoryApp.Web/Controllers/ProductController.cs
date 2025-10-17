using InMemoryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryApp.Web.Controllers
{

    public class ProductController : Controller
    {
        private IMemoryCache _memoryCache;
        private CacheService _cacheService;

        public ProductController(IMemoryCache memoryCache, CacheService cacheOptions)
        {
            _memoryCache = memoryCache;
            _cacheService = cacheOptions;
        }
        public IActionResult Index()
        {

            if (!_memoryCache.TryGetValue("zaman", out string? zamanCache))
            {
                _cacheService.Set("zaman", DateTime.Now.ToString());
            }
            return View();
        }

        public IActionResult Show()
        {
            ViewBag.Zaman = _memoryCache.Get<string>("zaman");
            return View();
        }
    }
}
