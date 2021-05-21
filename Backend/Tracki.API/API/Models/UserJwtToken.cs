using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
	public class UserJwtToken
	{
		public string Token { get; set; }
		public DateTime Expiration { get; set; }
	}
}
