using Solution.CrossCutting.Values;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public interface IUserDomain : IBaseDomain
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);

		string GenerateJwtToken(AuthenticatedModel authenticated);

		PagedList<UserModel> List(PagedListParameters parameters);

		void Logout(AuthenticatedModel authenticated);

		UserModel Select(long userId);
	}
}
