using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
	public static Claim GetClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
	{
		return claimsPrincipal?.FindFirst(claimType);
	}

	public static string GetClaimValueOfNameIdentifier(this ClaimsPrincipal claimsPrincipal)
	{
		return claimsPrincipal?.GetClaim(ClaimTypes.NameIdentifier)?.Value;
	}
}
