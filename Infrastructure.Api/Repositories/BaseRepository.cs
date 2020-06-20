using System;
using System.Collections.Generic;
using System.Text;
using Application.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Api.Repositories
{
    public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class 
    {
        #region fields
        private readonly IDbContext _context;
        private DbSet<TEntity> _entity;
        #endregion
        #region ctor
        public BaseRepository(IDbContext context)
        {
            _context = context;
        }
        #endregion ctor
        protected DbContext DbContext => (DbContext)_context;
        private DbSet<TEntity> Entity => _entity is null ? _entity = DbContext.Set<TEntity>() : _entity;
        public async Task Add(TEntity entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public async Task Complete()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entity.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await Entity.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            Entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entity.RemoveRange(entities);
        }
        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entity.Where(predicate).SingleOrDefaultAsync();
        }
    }
}
