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
	[Authorize(AuthenticationSchemes = "Bearer")]
	[EnableCors("AllAllowed")]
	public class UserController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<IdentityUser> userManager;

		public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			this.context = context;
			this.userManager = userManager;
		}

		[HttpGet]
		public async Task<ActionResult<UserBasicInfo>> GetUserProfile()
		{
			string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await userManager.FindByNameAsync(userID);
			return new UserBasicInfo
			{
				UserName = user.UserName,
				Email = user.Email,
			};
		}
	}
}
