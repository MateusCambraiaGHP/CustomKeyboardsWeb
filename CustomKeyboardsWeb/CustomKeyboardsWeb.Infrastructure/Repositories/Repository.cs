using CustomKeyboardsWeb.Domain.Entity;
using CustomKeyboardsWeb.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomKeyboardsWeb.Infrastructure.Repository
{
    public abstract class Repository<TEntity> where TEntity : Entity 
    {
        protected readonly IApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(
            IApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entityModel)
        {
            await _dbSet.AddAsync(entityModel);
            await _context.Save();
        }

        public virtual async Task<TEntity> Update(TEntity entityModel)
        {
            _dbSet.Update(entityModel);
            await _context.Save();
            return entityModel;
        }

        public virtual async Task<TEntity> FindById(int id)
        {
            var currentEntity = await _dbSet.AsNoTracking()
                .Where(c => c.Id == id).FirstOrDefaultAsync();
            return currentEntity;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            List<TEntity> currentEntity = await _dbSet.ToListAsync();
            currentEntity = currentEntity == null ? new List<TEntity>() : currentEntity;
            return currentEntity;
        }
    }
}
