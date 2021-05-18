using System;
using System.Collections.Generic;

#nullable disable

namespace TrackiBackEnd
{
    public partial class Photo
    {
        public Photo()
        {
            Releases = new HashSet<Release>();
            Users = new HashSet<User>();
        }

        public int PhotoId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Release> Releases { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
