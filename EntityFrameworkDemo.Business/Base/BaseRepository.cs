using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Business.Base
{
    public class BaseRepository<TEntity > : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

        public BaseRepository(IDbContextFactory<SubSystemDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        #region CreateAsync
        public async Task<TEntity?> CreateAsync(TEntity entity)
        {
            try
            {
                var context = _contextFactory.CreateDbContext();
                var newEntity = await context.Set<TEntity>().AddAsync(entity);
                if (newEntity == null)
                {
                    return null;
                }
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion

        #region DeleteAsync
        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                var context = _contextFactory.CreateDbContext();
                var entity = context.Set<TEntity>().Find(id);
                if (entity == null)
                {
                    return false;
                }
                context.Set<TEntity>().Remove(entity);
                var rowsAffected = await context.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            try
            {
                var context = _contextFactory.CreateDbContext();
                var entities = await context.Set<TEntity>().ToListAsync();
                if (entities == null)
                {
                    return null;
                }
                return entities;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion

        #region GetByIdAsync
        public async Task<TEntity?> GetByIdAsync(object id)
        {
            try
            {
                var context = _contextFactory.CreateDbContext();
                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return null;
                }
                return entity;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion

        #region UpdateAsync
        public async Task<TEntity?> UpdateAsync(TEntity entityUpdate)
        {
            try
            {
                var context = _contextFactory.CreateDbContext();
                context.Set<TEntity>().Attach(entityUpdate);
                context.Entry(entityUpdate).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entityUpdate;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion
    }
}
