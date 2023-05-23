using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkDemo.Business.Validations.Extensions
{
    public interface IDbContextValidationHelper<TContext> where TContext : DbContext
    {
        public Task<bool> DoesExist<TEntity>(Expression<Func<TEntity, bool>> exp) where TEntity : class;
        public Task<bool> DoesEntityExistWithEntity<TEntity>(Expression<Func<TEntity, bool>> exp) where TEntity : class; 
    }
}
