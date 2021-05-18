using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd.Model
{
    public partial class User
    {
        public User()
        {
            Artists = new HashSet<Artist>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int AccountTypeId { get; set; }
        public string PasswordHash { get; set; }
        public int? PhotoId { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
