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


        #region GetByIdAsyncIncludeDevice
        public async Task<SubSystem?> GetByIdAsyncIncludeDevice(int id)
        {
            try
            {
                var context = _contextFactory.CreateDbContext().Set<SubSystem>();
                var entity = await context.Include(x => x.Devices).Where(x => x.Id == id).FirstOrDefaultAsync();

                if (entity == null)
                {
                    return null;
                }
                return entity;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion


    }
}
