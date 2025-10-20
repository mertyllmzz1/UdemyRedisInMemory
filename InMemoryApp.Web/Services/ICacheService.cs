using Microsoft.Extensions.Caching.Memory;

namespace InMemoryApp.Web.Services
{
    public interface ICacheService
    {
        public void Set(string key, object value, CacheItemPriority priorty);

    }
}
