using System.Collections.Generic;

namespace API.Models
{
    public class UserDetailedInfo
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public List<ApplicationUser> Followers { get; set; }
        public List<ApplicationUser> Following { get; set; }
    }
}