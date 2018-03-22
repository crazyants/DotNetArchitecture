using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.Database.Repositories;

namespace Solution.Infrastructure.Databases.Database.UnitOfWork
{
	public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
	{
		public DatabaseUnitOfWork(
			DatabaseContext context,
			IUserLogRepository userLogRepository,
			IUserRepository userRepository,
			IUserRoleRepository userRoleRepository)
		{
			Context = context;
			UserLogRepository = userLogRepository;
			UserRepository = userRepository;
			UserRoleRepository = userRoleRepository;
		}

		public IUserLogRepository UserLogRepository { get; }
		public IUserRepository UserRepository { get; }
		public IUserRoleRepository UserRoleRepository { get; }
		private DatabaseContext Context { get; set; }

		public void Commit()
		{
			Context.SaveChanges();
		}

		public void Dispose()
		{
			if (Context == null) { return; }
			Context.Dispose();
			Context = null;
		}
	}
}
