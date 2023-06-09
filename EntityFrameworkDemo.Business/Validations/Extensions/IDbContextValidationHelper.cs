﻿using System.Linq.Expressions;

namespace EntityFrameworkDemo.Business.Validations.Extensions
{
    public interface IDbContextValidationHelper
    {
        Task<bool> DoesExist<TEntity>(object id) where TEntity : class;
        Task<bool> IsUniqueWithinEntity<TEntity>(Expression<Func<TEntity, bool>> exp) where TEntity : class;
    }
}
