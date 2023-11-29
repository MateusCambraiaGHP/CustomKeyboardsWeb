using CustomKeyboardsWeb.Data.Caching;
using StackExchange.Redis;
using System.Text.Json;

namespace CustomKeyboardsWeb.Infrastructure.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redis;
        private IDatabase _db;

        public CacheService(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = _redis.GetDatabase();
        }

        public async Task<IEnumerable<T>?> GetAll<T>(string key)
            where T : class
        {
            var value = _db.HashGetAll(key);
            if (value.Length > 0)
            {
                var jsonString = value.First().Value;
                var result = JsonSerializer.Deserialize<List<T>>(jsonString);
                return result;
            }

            return null;
        }

        public Task<T> GetData<T>(string key, string id)
            where T : class
        {
            var value = _db.HashGet(key, id);
            if (!value.IsNullOrEmpty)
            {
                var obj = JsonSerializer.Deserialize<T>(value);
                return Task.FromResult(obj);
            }
            return null;
        }

        public bool RemovePost(string key, string id)
        {
            bool isDeleted = _db.HashDelete(key, id);
            return isDeleted;
        }

        public T SetPost<T>(string key, T data)
            where T : class
        {
            var expirationTime = DateTimeOffset.Now.AddMinutes(60);
            var expiration = expirationTime.DateTime.Subtract(DateTime.Now);
            var serializedObject = JsonSerializer.Serialize(data);
            _db.HashSet(key, new HashEntry[]
            {
                new HashEntry(key, serializedObject)
            });
            _db.KeyExpire(key, expiration);
            return data;
        }

        public List<T> SetPost<T>(string key, List<T> data)
            where T : class
        {
            var expirationTime = DateTimeOffset.Now.AddMinutes(60);
            var expiration = expirationTime.DateTime.Subtract(DateTime.Now);

            var serializedObject = JsonSerializer.Serialize(data);
            _db.HashSet(key, new HashEntry[]
            {
                new HashEntry(key, serializedObject)
            });
            _db.KeyExpire(key, expiration);
            return data;
        }
    }
}
