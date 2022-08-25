using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using System.Security.Claims;

namespace QBD2.Services
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly ApplicationDbContext _context;

        public ClaimsTransformer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Clone current identity
            var clone = principal.Clone();
            var newIdentity = (ClaimsIdentity)clone.Identity;

            var nameIdentifier = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (nameIdentifier == null)
            {
                return principal;
            }

            // Get user from database
            var user = await _context.Users.Where(x => x.UserName == nameIdentifier.Value).FirstOrDefaultAsync();
            if (user != null)
            {
                var claim1 = new Claim("UserId", user.Id);
                newIdentity.AddClaim(claim1);

                var roles = await _context.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();
                
                // Add role claims to cloned identity
                if (roles == null)
                {
                    var role = await _context.Roles.Where(x => x.Name == "User").FirstOrDefaultAsync();
                    if (role != null)
                    {
                        ApplicationUserRole applicationUserRole = new ApplicationUserRole();
                        applicationUserRole.UserId = user.Id;
                        applicationUserRole.RoleId = role.Id;
                        await _context.AddAsync(applicationUserRole);
                        _context.SaveChanges();
                    }
                    roles = await _context.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();
                }

                if (roles != null)
                {
                    foreach (var role in roles.ToList())
                    {
                        var userRole = _context.Roles.Where(x => x.Id == role.RoleId).FirstOrDefault();
                        var claim = new Claim(newIdentity.RoleClaimType, userRole.Name);
                        newIdentity.AddClaim(claim);

                        var claim2 = new Claim("Role", userRole.Name);
                        newIdentity.AddClaim(claim2);
                    }
                }
            }
            else
            {
                var email = nameIdentifier.Value + "@lightspeedaviation.com";
                ApplicationUser applicationUser = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = nameIdentifier.Value,
                    NormalizedUserName = nameIdentifier.Value,
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ADLogin = nameIdentifier.Value
                };

                await _context.Users.AddAsync(applicationUser);
                _context.SaveChanges();

                var claim1 = new Claim("UserId", applicationUser.Id);
                newIdentity.AddClaim(claim1);

                var role = await _context.Roles.Where(x => x.Name == "User").FirstOrDefaultAsync();
                if (role != null)
                {
                    if (!await _context.UserRoles.AnyAsync(x=>x.UserId == applicationUser.Id && x.RoleId == role.Id))
                    {
                        ApplicationUserRole applicationUserRole = new ApplicationUserRole();
                        applicationUserRole.UserId = applicationUser.Id;
                        applicationUserRole.RoleId = role.Id;
                        await _context.AddAsync(applicationUserRole);
                        _context.SaveChanges();
                    }

                    var claim = new Claim(newIdentity.RoleClaimType, role.Name);
                    newIdentity.AddClaim(claim);

                    var claim2 = new Claim("Role", role.Name);
                    newIdentity.AddClaim(claim2);
                }
            }

            return clone;
        }
    }
}
