using Solution.CrossCutting.Values;
using Solution.Domain.Domains;
using Solution.Model.Models;

namespace Solution.Application.Applications
{
	public sealed class UserApplication : BaseApplication, IUserApplication
	{
		public UserApplication(IUserDomain userDomain)
		{
			UserDomain = userDomain;
		}

		public IUserDomain UserDomain { get; }

		public AuthenticatedModel Authenticate(AuthenticationModel authentication)
		{
			return UserDomain.Authenticate(authentication);
		}

		public string GenerateJwtToken(AuthenticatedModel authenticated)
		{
			return UserDomain.GenerateJwtToken(authenticated);
		}

		public PagedList<UserModel> List(PagedListParameters parameters)
		{
			return UserDomain.List(parameters);
		}

		public void Logout(AuthenticatedModel authenticated)
		{
			UserDomain.Logout(authenticated);
		}

		public UserModel Select(long userId)
		{
			return UserDomain.Select(userId);
		}
	}
}
