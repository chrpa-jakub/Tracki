using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd.Model
{
    public partial class Artist
    {
        public Artist()
        {
            Releases = new HashSet<Release>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistLocation { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Release> Releases { get; set; }
    }
}
