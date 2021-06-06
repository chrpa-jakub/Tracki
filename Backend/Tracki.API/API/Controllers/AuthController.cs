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
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly IConfiguration configuration;
		private readonly JWTTokenHelper jwtHelper;

		public AuthController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
			IConfiguration configuration, JWTTokenHelper jwtHelper)
		{
			this.context = context;
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.configuration = configuration;
			this.jwtHelper = jwtHelper;
		}

		[HttpPost("signup")]
		public async Task<ActionResult<UserJwtToken>> CreateUser([FromBody] UserSignupInfo userInfo)
		{
			var user = new ApplicationUser { UserName = userInfo.UserName, Email = userInfo.Email };
			var result = await userManager.CreateAsync(user, userInfo.Password);
			
			if (result.Succeeded) 
			{
				return Ok(result); 
			}

			return BadRequest("Invalid sign up attempt");
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserJwtToken>> Login([FromBody] UserSignupInfo userInfo)
		{
			var user = await userManager.FindByNameAsync(userInfo.UserName);

			if (user != null && await userManager.CheckPasswordAsync(user, userInfo.Password))
			{
				var token = jwtHelper.GenerateToken(user);
				return Ok(new { token });;
			}
			else
				return BadRequest(new { message = "Username or password is incorrect." });
		}
	}
}
