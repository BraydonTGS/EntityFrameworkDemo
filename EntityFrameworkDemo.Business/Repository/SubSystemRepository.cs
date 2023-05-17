using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Repository
{
    public class SubSystemRepository : BaseRepository<SubSystem>
    {
        private readonly SubSystemDbContext _context;

        public SubSystemRepository(SubSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
