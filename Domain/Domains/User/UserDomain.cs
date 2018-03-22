using System;
using System.Linq;
using Solution.CrossCutting.Security;
using Solution.CrossCutting.Values;
using Solution.Infrastructure.Databases.Database.UnitOfWork;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Model.Validations;

namespace Solution.Domain.Domains
{
	public sealed class UserDomain : BaseDomain, IUserDomain
	{
		public UserDomain(
			IDatabaseUnitOfWork databaseUnitOfWork,
			IHash hash,
			IJsonWebToken jsonWebToken
		)
		: base(databaseUnitOfWork)
		{
			Hash = hash;
			JsonWebToken = jsonWebToken;
		}

		private IHash Hash { get; }

		private IJsonWebToken JsonWebToken { get; }

		public AuthenticatedModel Authenticate(AuthenticationModel authentication)
		{
			new AuthenticationValidation().ValidateThrowException(authentication);
			authentication.Login = Hash.Generate(authentication.Login);
			authentication.Password = Hash.Generate(authentication.Password);
			var authenticated = DatabaseUnitOfWork.UserRepository.Authenticate(authentication);
			new AuthenticatedValidation().ValidateThrowException(authenticated);
			SaveUserLog(authenticated.UserId, LogType.Login);
			return authenticated;
		}

		public string GenerateJwtToken(AuthenticatedModel authenticated)
		{
			var sub = authenticated.UserId.ToString();
			var roles = authenticated.Roles.Select(role => role.ToString()).ToArray();
			return JsonWebToken.Encode(sub, roles);
		}

		public PagedList<UserModel> List(PagedListParameters parameters)
		{
			return DatabaseUnitOfWork.UserRepository.List(parameters);
		}

		public void Logout(AuthenticatedModel authenticated)
		{
			SaveUserLog(authenticated.UserId, LogType.Logout);
		}

		public UserModel Select(long userId)
		{
			return DatabaseUnitOfWork.UserRepository.Find(userId);
		}

		private void SaveUserLog(long userId, LogType logType)
		{
			var userLog = new UserLogModel
			{
				UserId = userId,
				LogType = logType,
				DateTime = DateTime.Now
			};

			DatabaseUnitOfWork.UserLogRepository.Add(userLog);
			DatabaseUnitOfWork.Commit();
		}
	}
}
