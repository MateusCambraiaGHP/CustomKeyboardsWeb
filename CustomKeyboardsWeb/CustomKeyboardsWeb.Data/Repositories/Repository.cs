using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.DomainObjects;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : Entity
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
        }

        public virtual async Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>>[] includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await (orderBy is not null ? orderBy(query) : query).ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entityModel)
        {
            _dbSet.Update(entityModel);
            return entityModel;
        }
    }
}
