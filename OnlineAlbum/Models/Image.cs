using System;

namespace OnlineAlbum.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Extension { get; set; }
        public DateTime UploadDate { get; set; }
        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}