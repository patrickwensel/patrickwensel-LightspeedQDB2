using Microsoft.AspNetCore.Identity;

namespace QBD2.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public IList<ApplicationUserRole> UserRoles { get; set; }
    }
}
