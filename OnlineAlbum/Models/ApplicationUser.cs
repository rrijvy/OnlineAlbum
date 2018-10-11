using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineAlbum.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Album> Albums { get; set; }
    }
}
