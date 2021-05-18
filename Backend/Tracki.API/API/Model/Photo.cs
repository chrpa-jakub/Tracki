using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackiBackEnd.Model
{
    public partial class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string Location { get; set; }
    }
}
