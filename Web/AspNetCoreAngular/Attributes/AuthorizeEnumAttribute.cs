using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Solution.Web.AspNetCoreAngular.Attributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
	public class AuthorizeEnumAttribute : AuthorizeAttribute
	{
		public AuthorizeEnumAttribute(params object[] roles)
		{
			if (roles.Any(role => role.GetType().BaseType != typeof(Enum)))
			{
				throw new ArgumentException("Roles must be of the Enum type.", nameof(roles));
			}

			Roles = string.Join(", ", roles.Select(role => Enum.GetName(role.GetType(), role)));
		}
	}
}