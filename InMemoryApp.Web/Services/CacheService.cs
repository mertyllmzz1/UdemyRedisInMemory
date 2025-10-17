using InMemoryApp.Web.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace InMemoryApp.Web.Services
{

    public class CacheService
    {
        private readonly IMemoryCache _cache;
        private readonly CacheSettings _cacheOptions;

        public CacheService(IMemoryCache cache, IOptions<CacheSettings> cacheOptions)
        {
            _cache = cache;
            _cacheOptions = cacheOptions.Value;
        }

        public void Set(string key, object value)
        {
            var memoryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(_cacheOptions.ExpirationInMinutes),
                SlidingExpiration = TimeSpan.FromSeconds(_cacheOptions.SlidingSeconds)
            };

            _cache.Set(key, value, memoryOptions);
        }
    }
}