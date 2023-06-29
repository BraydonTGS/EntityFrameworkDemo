using EntityFrameworkDemo.Business.Base;
using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.EntityFrameworkCore;

//------------------------------------------------------------
//
//
// THIS CODE IS AUTO GENERATED. DO NOT MAKE MANUAL CHANGES!!!
//
//
//------------------------------------------------------------
namespace EntityFrameworkDemo.Business.T4TextTemplates.Generated
{
	#region SubSystemRepository
	public partial class SubSystemRepository : BaseRepository<SubSystem>
	{
		private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

		public SubSystemRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
		{
			_contextFactory = contextFactory;
		}
	}
	#endregion

	#region DeviceRepository
	public partial class DeviceRepository : BaseRepository<Device>
	{
		private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

		public DeviceRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
		{
			_contextFactory = contextFactory;
		}
	}
	#endregion

	#region UserRepository
	public partial class UserRepository : BaseRepository<User>
	{
		private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

		public UserRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
		{
			_contextFactory = contextFactory;
		}
	}
	#endregion

	#region PasswordRepository
	public partial class PasswordRepository : BaseRepository<Password>
	{
		private readonly IDbContextFactory<SubSystemDbContext> _contextFactory;

		public PasswordRepository(IDbContextFactory<SubSystemDbContext> contextFactory) : base(contextFactory)
		{
			_contextFactory = contextFactory;
		}
	}
	#endregion
}