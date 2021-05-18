using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd.Model
{
    public partial class Release
    {
        public Release()
        {
            Songs = new HashSet<Song>();
        }

        public int ReleaseId { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public int YearOfRelease { get; set; }
        public int ReleaseTypeId { get; set; }
        public int? PhotoId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual ReleaseType ReleaseType { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
