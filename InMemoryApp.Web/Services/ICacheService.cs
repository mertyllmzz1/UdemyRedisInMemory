namespace InMemoryApp.Web.Services
{
    public interface ICacheService
    {
        public void Set(string key, object value);
    }
}
