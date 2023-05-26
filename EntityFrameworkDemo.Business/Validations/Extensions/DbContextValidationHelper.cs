using EntityFrameworkDemo.Business.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkDemo.Business.Validations.Extensions
{
    public class DbContextValidationHelper: IDbContextValidationHelper
    {
        private readonly SubSystemDbContext _context;

        public DbContextValidationHelper(SubSystemDbContext context)
        {
            _context = context;
        }

        #region DoesExist
        public async Task<bool> DoesExist<TEntity>(Expression<Func<TEntity, bool>> id) where TEntity : class
        {
            var entity = _context.Set<TEntity>();
            var result = await entity.AnyAsync(id);
            return result;
        }
        #endregion

        #region DoesEntityExistWithEntity
        public async Task<bool> IsUniqueWithinEntity<TEntity>(Expression<Func<TEntity, bool>> exp) where TEntity : class
        {
            var entity = _context.Set<TEntity>();
            var result = await entity.AnyAsync(exp);
            return !result;
        }
        #endregion
    }
}
