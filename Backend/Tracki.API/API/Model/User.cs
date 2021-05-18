using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackiBackEnd.Model
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public AccountType AccountType { get; set; }
        public string PasswordHash { get; set; }
        public int? PhotoId { get; set; }
    }
}
