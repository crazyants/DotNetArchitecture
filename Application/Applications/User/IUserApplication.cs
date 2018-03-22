using Solution.CrossCutting.Values;
using Solution.Model.Models;

namespace Solution.Application.Applications
{
	public interface IUserApplication : IBaseApplication
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);

		string GenerateJwtToken(AuthenticatedModel authenticated);

		PagedList<UserModel> List(PagedListParameters parameters);

		void Logout(AuthenticatedModel authenticated);

		UserModel Select(long userId);
	}
}
