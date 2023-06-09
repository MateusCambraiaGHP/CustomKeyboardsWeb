﻿using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomKeyboardsWeb.Data.Repositories
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
        }

        public virtual async Task<TEntity> Update(TEntity entityModel)
        {
            _dbSet.Update(entityModel);
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
