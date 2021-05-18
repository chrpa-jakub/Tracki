using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd.Model
{
    public partial class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int ReleaseId { get; set; }
        public string SongLocation { get; set; }

        public virtual Release Release { get; set; }
    }
}
