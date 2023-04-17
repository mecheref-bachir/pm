using project.Models.RegistrationModels.Dto;

namespace project.Models.ReportModels
{
    public class ManageUsersPageModel
    {
        public List<ApplicationUserDto> NonApprovedUsersList { get; set; }
        public Page Page { get; set; }
    }
}
