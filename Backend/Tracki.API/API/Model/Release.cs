using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackiBackEnd.Model
{
    public partial class Release
    {
        [Key]
        public int ReleaseId { get; set; }
        public string AlbumName { get; set; }
        public Artist Artist { get; set; }
        public int YearOfRelease { get; set; }
        public ReleaseType ReleaseType { get; set; }
        public int? PhotoId { get; set; }
    }
}
