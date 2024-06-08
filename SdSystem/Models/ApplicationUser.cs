using Microsoft.AspNetCore.Identity;

namespace SdSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Role { get; set; }
    }
}
