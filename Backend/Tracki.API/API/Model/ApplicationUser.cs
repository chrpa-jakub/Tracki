using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackiBackEnd.Model
{
    public partial class ApplicationUser : IdentityUser<Guid>
    {
        public int? PhotoId { get; set; }
    }
}
