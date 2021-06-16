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
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration _configuration;
		private readonly JWTTokenHelper _jwtHelper;

		public AuthController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
			IConfiguration configuration, JWTTokenHelper jwtHelper)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
			_jwtHelper = jwtHelper;
		}

		[HttpPost("signup")]
		public async Task<ActionResult<UserJwtToken>> CreateUser([FromBody] UserSignupInfo userInfo)
		{ 
			var user = new ApplicationUser { UserName = userInfo.UserName, Email = userInfo.Email, Photo="https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=612x612&w=0&h=NGxdexflb9EyQchqjQP0m6wYucJBYLfu46KCLNMHZYM="};
			var result = await _userManager.CreateAsync(user, userInfo.Password);
			
			if (result.Succeeded) 
			{
				return Ok(result); 
			}

			return BadRequest("Invalid sign up attempt");
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserJwtToken>> Login([FromBody] UserSignupInfo userInfo)
		{
			var user = await _userManager.FindByNameAsync(userInfo.UserName);

			if (user != null && await _userManager.CheckPasswordAsync(user, userInfo.Password))
			{
				var token = _jwtHelper.GenerateToken(user);
				return Ok(new { token });;
			}
			else
				return BadRequest(new { message = "Username or password is incorrect." });
		}
		
	}
}
