using System.ComponentModel.DataAnnotations;

namespace QBD2.Models
{
    public class ApplicationUserModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string>? SelectedRoleIds { get; set; }
        public string RoleName { get; set; }
    }

    public class EditApplicationUserRoleModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "The Role field is required.")]
        public List<string>? SelectedRoleIds { get; set; }
    }
}
