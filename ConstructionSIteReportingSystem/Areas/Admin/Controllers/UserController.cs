using ConstructionSiteReportingSystem.Core.Models.Admin.User;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static ConstructionSiteReportingSystem.Core.Constants.AdministratorConstants;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class UserController : AdminBaseController
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var users = _userManager.Users
				.Where(u => u.Email != AdminEmail)
				.Select(u => new UserViewModel()
				{
					Id = u.Id,
					Email = u.Email,
					FirstName = u.FirstName,
					MiddleName = u.LastName,
					LastName = u.LastName
				})
				.ToList();

			var admins = await _userManager.GetUsersInRoleAsync(AdminRole);

			users.ForEach(u => u.IsAdmin = true ? admins.Any(a => a.Email == u.Email) : false);

			return View(users);
		}

		[HttpPost]
		public async Task<IActionResult> MakeAdmin(string email)
		{
			var newAdminUser = await _userManager.FindByEmailAsync(email);

			if (newAdminUser == null)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await _userManager.AddToRoleAsync(newAdminUser, AdminRole);

			TempData[UserInfoMessage] = $"You have successfully made {newAdminUser.FirstName} {newAdminUser.MiddleName} {newAdminUser.LastName} an administrator.";

			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> RemoveAdmin(string email)
		{
			var adminUser = await _userManager.FindByEmailAsync(email);

			if (adminUser == null)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await _userManager.RemoveFromRoleAsync(adminUser, AdminRole);

            TempData[UserInfoMessage] = $"You have successfully removed {adminUser.FirstName} {adminUser.MiddleName} {adminUser.LastName} from the administrator list.";

            return RedirectToAction(nameof(All));
		}
	}
}