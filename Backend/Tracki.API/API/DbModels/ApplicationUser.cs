﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public string Photo { get; set; }
        public List<ApplicationUser> Followers { get; set; }
        public List<ApplicationUser> Following { get; set; }
    }
}
