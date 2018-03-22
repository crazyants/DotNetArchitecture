using Solution.Infrastructure.Databases.Database.Repositories;

namespace Solution.Infrastructure.Databases.Database.UnitOfWork
{
	public interface IDatabaseUnitOfWork
	{
		IUserLogRepository UserLogRepository { get; }

		IUserRepository UserRepository { get; }

		IUserRoleRepository UserRoleRepository { get; }

		void Commit();

		void Dispose();
	}
}
