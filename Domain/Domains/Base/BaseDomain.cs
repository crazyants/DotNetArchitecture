using Solution.Infrastructure.Databases.Database.UnitOfWork;

namespace Solution.Domain.Domains
{
	public abstract class BaseDomain : IBaseDomain
	{
		protected BaseDomain(IDatabaseUnitOfWork databaseUnitOfWork)
		{
			DatabaseUnitOfWork = databaseUnitOfWork;
		}

		public IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
	}
}
