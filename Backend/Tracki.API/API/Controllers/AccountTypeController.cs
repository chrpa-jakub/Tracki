using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackiBackEnd.Model;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountTypeController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public AccountTypeController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<AccountType>>> Get()
		{
			return await context.AccountTypes.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(AccountType accountType)
		{
			context.Add(accountType);
			await context.SaveChangesAsync();
			return accountType.TypeId;
		}


	}
}
