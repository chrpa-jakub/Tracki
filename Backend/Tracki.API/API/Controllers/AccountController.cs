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
using API.Helpers;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("AllAllowed")]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class AccountController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JWTTokenHelper _jwtHelper;
		private readonly AzureStorageService _storageService;

		public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, JWTTokenHelper jwtHelper, AzureStorageService storageService)
		{
			_context = context;
			_userManager = userManager;
			_jwtHelper = jwtHelper;
			_storageService = storageService;
		}

		[HttpGet("overview")]
		public async Task<ActionResult<UserBasicInfo>> GetUserProfile()
		{
			var claimsIdentity = User.Identity as ClaimsIdentity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
			var user = await _userManager.FindByIdAsync(userId);

			if (user != null)
			{
				return new UserBasicInfo
				{
					UserName = user.UserName,
					Email = user.Email,
					Photo = user.Photo
				};
			}

			return BadRequest();
		}

		[HttpPost("edit")]
		public async Task<ActionResult> EditProfileInfo([FromBody] UserSignupInfo userInfo)
		{
			var claimsIdentity = User.Identity as ClaimsIdentity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
			var user = await _userManager.FindByIdAsync(userId);

			if (user != null)
			{
				user.Email = userInfo.Email;
				user.UserName = userInfo.UserName;
				
				if(!string.IsNullOrWhiteSpace(userInfo.Photo))
				{
					var userPhoto = Convert.FromBase64String(userInfo.Photo);
					if(String.IsNullOrEmpty(user.Photo))
                    {
						user.Photo = await _storageService.SaveFile(userPhoto, ".jpg", "users");
					}
					else
                    {
						user.Photo = await _storageService.EditFile(userPhoto, ".jpg", "users", user.Photo);
					}
				}

				if(userInfo.Password != "" && userInfo.Password.Length >= 6)
				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);
					await _userManager.ResetPasswordAsync(user, token, userInfo.Password);
				}
				await _userManager.UpdateAsync(user);

				return Ok();
			}

			return BadRequest();
		}
	}
}
