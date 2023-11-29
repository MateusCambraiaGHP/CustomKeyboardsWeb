namespace CustomKeyboardsWeb.Data.Caching
{
    public interface ICacheService
    {
        Task<IEnumerable<T>?> GetAll<T>(string key)
            where T : class;
        Task<T> GetData<T>(string key, string id)
            where T : class;
        bool RemovePost(string key, string id);
        T SetPost<T>(string key, T post)
            where T : class;
        List<T> SetPost<T>(string key, List<T> data)
            where T : class;
    }
}
