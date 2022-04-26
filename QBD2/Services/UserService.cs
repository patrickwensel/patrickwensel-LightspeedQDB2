using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;

        public UserService( ApplicationDbContext context)
        {
            //_signInManager = signInManager;
            //_userManager = usrMgr;
            _context = context;
            //_roleManager = roleMgr;
        }
        public async Task Create(ApplicationUser itemToInsert)
        {
            _context.Users.Add(itemToInsert);
            await _context.SaveChangesAsync();
            }

        public async Task<List<ApplicationUser>> Read()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            var roles = await _context.Roles.ToListAsync();
            var users = await _context.Users.Select(s => new ApplicationUser
            {
                AccessFailedCount = s.AccessFailedCount,
            SecurityStamp = s.SecurityStamp,
            ConcurrencyStamp = s.ConcurrencyStamp,
            Email = s.Email,
            EmailConfirmed = s.EmailConfirmed,
             Id = s.Id,
             LockoutEnabled = s.LockoutEnabled,
             LockoutEnd = s.LockoutEnd,
             NormalizedEmail = s.NormalizedEmail,
             NormalizedUserName = s.NormalizedUserName,
             PasswordHash = s.PasswordHash,
             PhoneNumber = s.PhoneNumber,
             PhoneNumberConfirmed = s.PhoneNumberConfirmed,
             TwoFactorEnabled = s.TwoFactorEnabled,
             UserName = s.UserName,
             ADLogin = s.UserName,
            })?.ToListAsync();

            foreach (var item in users)
            {
                item.UserRoles = userRoles.Where(x => x.UserId == x.UserId)
             .Select(t => new ApplicationUserRole
             {
                 RoleId = t.RoleId,
                 UserId = t.UserId,
                 Role = roles.Where(r => r.Id == t.RoleId).Select(g => new ApplicationRole
                 {
                     Id = g.Id,
                     ConcurrencyStamp = g.ConcurrencyStamp,
                     Name = g.Name,
                     NormalizedName = g.NormalizedName,
                 }).FirstOrDefault()
             })?.ToList();
            }

            return users;
        }

        public async Task Update(ApplicationUser itemToUpdate)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Id == itemToUpdate.Id);
            if (user != null)
            {
                user.UserName = itemToUpdate.UserName;
                user.Email = itemToUpdate.Email;
                _context.Users.Update(user);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ApplicationUser itemToDelete)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Id == itemToDelete.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task<IEnumerable<DropDownBindString>> GetRoleSelectList()
        {
            return await _context.Roles
             .Select(c => new DropDownBindString
             {
                 DropValue = c.Id,
                 DropText = c.Name
             }).ToListAsync();
        }
    }
}
