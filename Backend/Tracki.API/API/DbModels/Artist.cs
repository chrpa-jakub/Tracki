using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
