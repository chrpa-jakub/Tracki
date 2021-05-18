using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackiBackEnd.Model;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public UserController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<User>>> Get()
		{
			return await context.Users.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(User user)
		{
			context.Add(user);
			await context.SaveChangesAsync();
			return user.UserId;
		}

	}
}
