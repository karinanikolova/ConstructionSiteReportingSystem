using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Areas.Admin.Models.User;
using static ConstructionSiteReportingSystem.Core.Constants.AdministratorConstants;
using System.Security.Claims;

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
			var headAdmin = await _userManager.FindByEmailAsync(AdminEmail);
			var admins = await _userManager.GetUsersInRoleAsync(AdminRole);
			var currentUserId = User.Id();

			var users = _userManager.Users
				.Where(u => u.Email != headAdmin.Email && u.Id != currentUserId)
				.Select(u => new UserViewModel()
				{
					Email = u.Email,
					FirstName = u.FirstName,
					MiddleName = u.LastName,
					LastName = u.LastName
				})
				.ToList();

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

			return RedirectToAction(nameof(All));
		}
	}
}