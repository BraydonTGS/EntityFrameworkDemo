using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Business.Repository
{
    public class PasswordRepository : BaseRepository<Password>
    {
        private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

        public PasswordRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
