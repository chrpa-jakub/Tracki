using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackiBackEnd.Model
{
    public partial class ReleaseType
    {
        [Key]
        public int ReleaseTypeId { get; set; }
        public string ReleaseTypeName { get; set; }
    }
}
