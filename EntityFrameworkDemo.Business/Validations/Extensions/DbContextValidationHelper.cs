using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkDemo.Business.Validations.Extensions
{
    public class DbContextValidationHelper<TContext> where TContext : DbContext, IDbContextValidationHelper<TContext>
    {
        private readonly TContext _context;

        public DbContextValidationHelper(TContext context)
        {
            _context = context;
        }

        #region DoesExist
        public async Task<bool> DoesExist<TEntity>(Expression<Func<object, bool>> id) where TEntity : class
        {
            var entity = _context.Set<TEntity>();
            var result = await entity.AnyAsync(id);
            return result;
        }
        #endregion

        #region DoesEntityExistWithEntity
        public async Task<bool> DoesEntityExistWithEntity<TEntity>(Expression<Func<TEntity, bool>> exp) where TEntity : class
        {
            var entity = _context.Set<TEntity>();
            var result = await entity.AnyAsync(exp);
            return result;
        }
        #endregion
    }
}
