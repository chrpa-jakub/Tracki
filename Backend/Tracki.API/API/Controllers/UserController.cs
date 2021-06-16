using API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("AllAllowed")]
	//[Authorize(AuthenticationSchemes = "Bearer")]
	public class UserController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		[HttpGet("{username}")]
		public async Task<ActionResult<UserDetailedInfo>> GetUserByUsername(string username)
		{
			var user = await _userManager.FindByNameAsync(username);

			if (user != null)
			{
				return new UserDetailedInfo()
				{
					Email = user.Email,
					Photo = user.Photo,
					UserName = user.UserName,
					Followers = user.Followers,
					Following = user.Following
				};
			}

			return BadRequest("User does not exist.");
		}
		
		[HttpGet("search/{searchText}")]
		public async Task<ActionResult<List<UserBasicInfo>>> SearchForUsers(string searchText)
		{
			List<UserBasicInfo> foundUsers = new List<UserBasicInfo>();
			var usersByUsername = _context.Users.OfType<ApplicationUser>().Where(s => s.UserName.Contains(searchText)).ToList();
			var usersByEmail = _context.Users.OfType<ApplicationUser>().Where(s => s.Email.Contains(searchText)).ToList();
			var allUsers = usersByUsername.Union(usersByEmail).ToList();
			
			foreach (var user in allUsers)
			{
				foundUsers.Add(new UserBasicInfo()
				{
					Email = user.Email,
					UserName = user.UserName,
					Photo = user.Photo
				});
			}
			
			if (foundUsers.Count != 0)
			{
				return foundUsers;
			}

			return BadRequest("User does not exist.");
		}
		
		[HttpGet("all")]
		public async Task<ActionResult<List<UserBasicInfo>>> GetAllUsers()
		{
			var allUsers = _context.Users.OfType<ApplicationUser>().ToList();
			List<UserBasicInfo> userInfo = new List<UserBasicInfo>();
			
			foreach (var user in allUsers)
			{
				userInfo.Add(new UserBasicInfo()
				{
					Email = user.Email,
					Photo = user.Photo,
					UserName = user.UserName
				});
			}

			return userInfo;
		}
	}
}
