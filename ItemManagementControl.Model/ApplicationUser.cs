using Microsoft.AspNetCore.Identity;

namespace ItemManagementControl.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? StreetAddress { get; set; } = default!;
    }
}
