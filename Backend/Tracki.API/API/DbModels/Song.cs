using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class Song
    {
        [Key]
        public int SongID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [ForeignKey("ArtistID")]
        public Artist Artist { get; set; }
        public int YearOfRelease { get; set; }
        public string Photo { get; set; }
    }
}
