using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Repository
{
    public class DeviceRepository : BaseRepository<Device>
    {
        private readonly SubSystemDbContext _context;

        public DeviceRepository(SubSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
