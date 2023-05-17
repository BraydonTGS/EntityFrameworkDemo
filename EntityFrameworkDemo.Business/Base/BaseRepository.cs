using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Interfaces;

namespace EntityFrameworkDemo.Business.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SubSystemDbContext _context;

        public BaseRepository(SubSystemDbContext context)
        {
            _context = context;
        }
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
