using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class ReleaseType
    {
        [Key]
        public int ReleaseTypeId { get; set; }
        public string ReleaseTypeName { get; set; }
    }
}
