namespace ConstructionSiteReportingSystem.Areas.Admin.Models.User
{
	public class UserViewModel
	{
		public string Email { get; set; } = string.Empty;

		public string FirstName { get; set; } = string.Empty;

		public string MiddleName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public bool IsAdmin { get; set; }
	}
}