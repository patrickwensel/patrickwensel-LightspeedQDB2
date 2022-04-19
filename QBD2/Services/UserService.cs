using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> usrMgr, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = usrMgr;
            _context = context;
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
    }
}
