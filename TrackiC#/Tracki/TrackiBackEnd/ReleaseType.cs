using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd
{
    public partial class ReleaseType
    {
        public ReleaseType()
        {
            Releases = new HashSet<Release>();
        }

        public int ReleaseTypeId { get; set; }
        public string ReleaseTypeName { get; set; }

        public virtual ICollection<Release> Releases { get; set; }
    }
}
