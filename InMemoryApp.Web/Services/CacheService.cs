using InMemoryApp.Web.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace InMemoryApp.Web.Services
{

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly CacheSettings _cacheOptions;

        public CacheService(IMemoryCache cache, IOptions<CacheSettings> cacheOptions)
        {
            _cache = cache;
            _cacheOptions = cacheOptions.Value;
        }

        public void Set(string key, object value, CacheItemPriority priorty)
        {
            var memoryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(_cacheOptions.ExpirationInMinutes),
                SlidingExpiration = TimeSpan.FromSeconds(_cacheOptions.SlidingSeconds),
                Priority = priorty
            };

            memoryOptions.RegisterPostEvictionCallback((k, v, reason, state) =>
            {
                // Loglama veya ek işlemler burada yapılabilir
                _cache.Set("callback", $"Key: {k} => Value:{v},=> Reason: {reason}");
            });

            _cache.Set(key, value, memoryOptions);
        }

    }
}