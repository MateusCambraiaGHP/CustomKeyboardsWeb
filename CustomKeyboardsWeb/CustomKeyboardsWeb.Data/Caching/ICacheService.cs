namespace CustomKeyboardsWeb.Data.Caching
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;
        Task SetAsync<T>(string key, T values, CancellationToken cancellationToken = default)
            where T : class;
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
        Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default);
    }
}
