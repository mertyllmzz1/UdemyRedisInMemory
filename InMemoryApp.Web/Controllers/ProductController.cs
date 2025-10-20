using InMemoryApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryApp.Web.Controllers
{

    public class ProductController : Controller
    {
        private IMemoryCache _memoryCache;
        private ICacheService _cacheService;

        public ProductController(IMemoryCache memoryCache, ICacheService cacheOptions)
        {
            _memoryCache = memoryCache;
            _cacheService = cacheOptions;
        }
        public IActionResult Index()
        {

            if (!_memoryCache.TryGetValue("zaman", out string? zamanCache))
            {
                _cacheService.Set("zaman", DateTime.Now.ToString(),CacheItemPriority.Normal);
            }
            return View();
        }

        public IActionResult Show()
        {
            _memoryCache.TryGetValue("zaman", out string? zamanCache);
            _memoryCache.TryGetValue("callback", out string? callback);
            ViewBag.Zaman = zamanCache;
            ViewBag.CallBack = callback;

            return View();
        }
    }
}
