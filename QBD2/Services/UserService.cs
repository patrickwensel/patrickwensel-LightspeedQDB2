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
                                                                      select new ApplicationUserModel
                                                                      {
                                                                          UserId = u.Id,
                                                                          Email = u.Email,
                                                                          UserName = u.UserName,
                                                                          SelectedRoleIds = _context.UserRoles.Where(x=>x.UserId == u.Id).Select(x=>x.RoleId).ToList()
                                                                      }).ToListAsync();

            foreach (var userItem in applicationUserModels)
            {
                if (userItem != null && userItem.SelectedRoleIds != null)
                {
                    var selectedRoles = await _context.Roles.Where(x => userItem.SelectedRoleIds.Contains(x.Id)).OrderBy(a=>a.Name).Select(b => b.Name).ToListAsync();
                    if (selectedRoles != null)
                    {
                        userItem.RoleName = String.Join(", ", selectedRoles);
                    }
                }
            }

            return applicationUserModels;
        }

        public async Task<Models.ApiResponse> EditRole(EditApplicationUserRoleModel model)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();
            try
            {

                if (model != null && model.SelectedRoleIds != null && model.SelectedRoleIds.Any())
                {
                    var userRoles = await _context.UserRoles.Where(x => x.UserId == model.UserId).ToListAsync();
                    if (userRoles != null && userRoles.Any())
                    {
                        _context.UserRoles.RemoveRange(userRoles);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var roleId in model.SelectedRoleIds)
                    {
                        ApplicationUserRole applicationUserRole = new ApplicationUserRole();
                        applicationUserRole.UserId = model.UserId;
                        applicationUserRole.RoleId = roleId;
                        _context.UserRoles.Add(applicationUserRole);
                        await _context.SaveChangesAsync();
                    }

                    apiResponse.Success = true;
                    apiResponse.Message = "Record Saved Successfully.";
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Please select user roles.";
                   
                }

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
             }).OrderBy(a=>a.DropText).ToListAsync();
        }

        public async Task<List<string>> GetUserRolesById(string userId)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                List<string> userRole = new List<string>();
                var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user != null)
                {
                    var userRoleIds = _context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
                    userRole = await _context.Roles.Where(x => userRoleIds.Contains(x.Id)).OrderBy(a => a.Name).Select(b => b.Name).ToListAsync();
                    return userRole;
                }
            }
            return null;
        }
    }
}
