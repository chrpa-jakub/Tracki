using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackiBackEnd.Model
{
    public partial class AccountType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
