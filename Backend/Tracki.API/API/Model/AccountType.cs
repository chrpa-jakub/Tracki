using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd.Model
{
    public partial class AccountType
    {
        public AccountType()
        {
            Users = new HashSet<User>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
