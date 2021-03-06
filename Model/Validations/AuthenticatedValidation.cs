﻿using System.Linq;
using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Values;
using Solution.Model.Models;

namespace Solution.Model.Validations
{
	public sealed class AuthenticatedValidation : Validation<AuthenticatedModel>
	{
		public override ValidationResult Validate(AuthenticatedModel model)
		{
			var validationResult = new ValidationResult();

			if (model == null || model.UserId == 0 || model.Roles == null || !model.Roles.Any())
			{
				validationResult.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
			}

			return validationResult;
		}
	}
}
