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
        public DeviceRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
