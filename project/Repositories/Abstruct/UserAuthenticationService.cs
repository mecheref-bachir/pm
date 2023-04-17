using project.Models.RegistrationModels.Dto;
using project.Models.ReportModels;

namespace project.Repositories.Abstruct
{
    public interface UserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(Registration RegistrationModel);
        Task LogoutAsync();

        ManageUsersPageModel GetAllNonApprovedUsers(int PageNumber, string operation);

        Task<Status> ApproveUser(string UserName);
        Task<Status> DeleteUserAsync(string UserName);

    }
}
