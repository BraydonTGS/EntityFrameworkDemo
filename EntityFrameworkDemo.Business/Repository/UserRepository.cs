using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Business.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;
        public UserRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
