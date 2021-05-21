using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class Song
    {
        [Key]
        public int SongId { get; set; }
        public string SongName { get; set; }
        public ReleaseType ReleaseType { get; set; }
        public string SongLocation { get; set; }
    }
}
