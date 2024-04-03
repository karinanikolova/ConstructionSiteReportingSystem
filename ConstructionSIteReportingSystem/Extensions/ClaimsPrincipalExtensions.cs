namespace System.Security.Claims
{
	public static class ClaimsPrincipalExtensions
	{
		/// <summary>
		/// Providing a method to be used across the application for retrieving the hashed user identifier as a string.
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
