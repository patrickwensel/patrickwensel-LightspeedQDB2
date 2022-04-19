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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> usrMgr, ApplicationDbContext context, RoleManager<ApplicationRole> roleMgr)
        {
            _signInManager = signInManager;
            _userManager = usrMgr;
            _context = context;
            _roleManager = roleMgr;
        }
        public static async Task Create(ApplicationUser itemToInsert)
        {

        }

        public async Task<List<ApplicationUser>> Read()
        {
            return await _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
        }

        public static async Task Update(ApplicationUser itemToUpdate)
        {

        }

        public static async Task Delete(ApplicationUser itemToDelete)
        {

        }

        public async Task<IEnumerable<DropDownBindString>> GetRoleSelectList()
        {
            return await _roleManager.Roles
             .Select(c => new DropDownBindString
             {
                 DropValue = c.Id,
                 DropText = c.Name
             }).ToListAsync();
        }
    }
}
