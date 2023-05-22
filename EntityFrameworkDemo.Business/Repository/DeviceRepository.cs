using AutoMapper;
using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Business.Repository
{
    public partial class DeviceRepository : BaseRepository<Device>
    {
        private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;
        private readonly IMapper _mapper;

        public DeviceRepository(IDbContextFactory<SubSystemDbContext> contextFactory, IMapper mapper) : base(contextFactory)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        #region MapDtoToEntity
        // Todo: Move to BL implementation //
        public async Task<DeviceDto?> MapDtoToEntity(DeviceDto device)
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = _mapper.Map<Device>(device);
            context.Add(entity);
            var rowsAffected = await context.SaveChangesAsync();
            if (rowsAffected > 0)
            {
                return device;
            }
            return null;
        }
        #endregion
    }
}
