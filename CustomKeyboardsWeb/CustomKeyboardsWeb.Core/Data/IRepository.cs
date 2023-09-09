namespace CustomKeyboardsWeb.Core.Data
{
    public interface IRepository<TEntity>
    {
        Task Create(TEntity entityModel);

        Task<TEntity> Update(TEntity entityModel);

        Task<TEntity> FindById(Guid id);

        Task<List<TEntity>> GetAll();
    }
}
