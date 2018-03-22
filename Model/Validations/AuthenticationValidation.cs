using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Values;
using Solution.Model.Models;

namespace Solution.Model.Validations
{
	public sealed class AuthenticationValidation : Validation<AuthenticationModel>
	{
		public override ValidationResult Validate(AuthenticationModel model)
		{
			var validationResult = new ValidationResult();

			if (string.IsNullOrEmpty(model?.Login) || string.IsNullOrEmpty(model.Password))
			{
				validationResult.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
			}

			return validationResult;
		}
	}
}