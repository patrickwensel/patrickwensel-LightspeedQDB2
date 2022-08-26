using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;
using static QBD2.Models.Enum;

namespace QBD2.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUserModel>> Read()
        {
            List<ApplicationUserModel> applicationUserModels = await (from u in _context.Users
                                                                      join ur in _context.UserRoles on u.Id equals ur.UserId into ur_join
                                                                      from ur in ur_join.DefaultIfEmpty()
                                                                      join r in _context.Roles on ur.RoleId equals r.Id into r_join
                                                                      from r in r_join.DefaultIfEmpty()
                                                                      select new ApplicationUserModel
                                                                      {
                                                                          UserId = u.Id,
                                                                          Email = u.Email,
                                                                          UserName = u.UserName,
                                                                          RoleId = ur.RoleId,
                                                                          RoleName = r.Name
                                                                      }).ToListAsync();

            return applicationUserModels;
        }

        public async Task<Models.ApiResponse> EditRole(EditApplicationUserRoleModel model)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();
            try
            {
                var userRoles = await _context.UserRoles.Where(x => x.UserId == model.UserId).ToListAsync();
                if (userRoles != null && userRoles.Any())
                {
                    _context.UserRoles.RemoveRange(userRoles);
                    await _context.SaveChangesAsync();
                }

                ApplicationUserRole applicationUserRole = new ApplicationUserRole();
                applicationUserRole.UserId = model.UserId;
                applicationUserRole.RoleId = model.RoleId;
                _context.UserRoles.Add(applicationUserRole);
                await _context.SaveChangesAsync();

                apiResponse.Success = true;
                apiResponse.Message = "Record Saved Successfully.";
                return apiResponse;
            }
            catch
            {
                apiResponse.Success = false;
                apiResponse.Message = "Record Not Saved ! Something Worng.";
                return apiResponse;
            }
        }

        public async Task<List<DropDownBindString>> GetRoleDropdown()
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
