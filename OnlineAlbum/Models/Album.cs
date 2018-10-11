using System.Collections.Generic;

namespace OnlineAlbum.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<Image> Images { get; set; }

    }
}
