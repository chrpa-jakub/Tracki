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
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly IConfiguration configuration;

		public AuthController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
		{
			this.context = context;
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.configuration = configuration;
		}

		[HttpPost("Create")]
		public async Task<ActionResult<UserJwtToken>> CreateUser([FromBody] UserSignupInfo model)
		{
			var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
			var result = await userManager.CreateAsync(user, model.Password);

			if (result.Succeeded) { return await BuildToken(model); }

			return BadRequest("Username or password invalid");
		}

		[HttpPost("Login")]
		public async Task<ActionResult<UserJwtToken>> Login([FromBody] UserSignupInfo userInfo)
		{
			var result = await signInManager.PasswordSignInAsync(userInfo.UserName,
				userInfo.Password, isPersistent: false, lockoutOnFailure: false);

			if (result.Succeeded) { return await BuildToken(userInfo); }

			return BadRequest("Invalid login attempt");
		}

		private async Task<UserJwtToken> BuildToken(UserSignupInfo userInfo)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, userInfo.UserName),
				new Claim(ClaimTypes.Email, userInfo.Email),
				new Claim(ClaimTypes.Role, "User")

			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expiration = DateTime.UtcNow.AddYears(1);

			JwtSecurityToken token = new JwtSecurityToken(
			   issuer: null,
			   audience: null,
			   claims: claims,
			   expires: expiration,
			   signingCredentials: creds);

			return new UserJwtToken()
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = expiration
			};

		}
	}
}
