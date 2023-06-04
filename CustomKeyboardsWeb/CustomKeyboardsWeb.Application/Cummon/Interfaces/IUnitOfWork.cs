namespace CustomKeyboardsWeb.Application.Cummon.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
