using Microsoft.AspNetCore.Identity;

namespace QBD2.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ADLogin { get; set; }
        public IList<ApplicationUserRole>? UserRoles { get; set; }
    }
}
