using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.Database.UnitOfWork;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Tests
{
	[TestClass]
	public class DatabaseTest
	{
		public DatabaseTest()
		{
			Container.RegisterServices();
			Container.AddDbContextInMemoryDatabase<DatabaseContext>();
			DatabaseUnitOfWork = Container.GetService<IDatabaseUnitOfWork>();
		}

		public IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

		[TestMethod]
		public void DatabaseUnitOfWork_Repository()
		{
			// Add
			var userAdd = new UserModel
			{
				Name = "Name",
				Surname = "Surname",
				Email = "email@email.com",
				Login = "login",
				Password = "password",
				Status = Status.Active
			};

			// Add
			DatabaseUnitOfWork.UserRepository.Add(userAdd);
			DatabaseUnitOfWork.Commit();

			// Select
			var userExists = DatabaseUnitOfWork.UserRepository.Find(userAdd.UserId);

			// Update
			userExists.Name = "Updated";
			DatabaseUnitOfWork.UserRepository.Update(userExists, userAdd.UserId);
			DatabaseUnitOfWork.Commit();

			// Delete
			DatabaseUnitOfWork.UserRepository.Delete(userAdd.UserId);
			DatabaseUnitOfWork.Commit();

			// Count
			var count = DatabaseUnitOfWork.UserRepository.Count();
			Assert.IsTrue(count > 0);
		}
	}
}
