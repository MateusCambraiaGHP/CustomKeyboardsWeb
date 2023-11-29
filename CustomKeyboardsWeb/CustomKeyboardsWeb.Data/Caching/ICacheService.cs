using CustomKeyboardsWeb.Application.Features.ViewModel.Commom;

namespace CustomKeyboardsWeb.Data.Caching
{
    public interface ICacheService
    {
        Task<IEnumerable<T>?> GetAll<T>(string key)
            where T : BaseViewModel;
        Task<T> GetData<T>(string key, string id)
            where T : BaseViewModel;
        bool RemovePost(string key, string id);
        T SetPost<T>(string key, T post)
            where T : BaseViewModel;
        List<T> SetPost<T>(string key, List<T> posts)
            where T : BaseViewModel;
    }
}
