namespace CustomKeyboardsWeb.Core.Data
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
