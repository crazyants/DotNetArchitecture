using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.Database.EntityTypeConfigurations;
using Solution.Infrastructure.Databases.EntityFrameworkCore;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Context
{
	public sealed class DatabaseContext : EntityFrameworkCoreContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserModel> User { get; set; }

		public DbSet<UserLogModel> UserLog { get; set; }

		public DbSet<UserRoleModel> UserRole { get; set; }

		protected override void OnModelCreatingCustom(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserLogEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserRoleEntityTypeConfiguration());
		}

		protected override void Seed()
		{
			SaveUserAdministrador();
			SaveChanges();
		}

		private void SaveUserAdministrador()
		{
			if (User.Find(1L) != null) { return; }

			var _hash = new Hash();

			var userModel = new UserModel
			{
				Name = "Administrator",
				Surname = "Administrator",
				Email = "administrator@administrator.com",
				Login = _hash.Generate("admin"),
				Password = _hash.Generate("admin"),
				Status = Status.Active
			};

			var userRoleModel = new UserRoleModel { UserId = 1, Role = Role.Admin };

			Set<UserModel>().Add(userModel);

			Set<UserRoleModel>().Add(userRoleModel);
		}
	}
}
