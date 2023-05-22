using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Business.Repository
{
    public partial class SubSystemRepository : BaseRepository<SubSystem>
    {
        private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

        public SubSystemRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
