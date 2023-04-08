using project.Models.RegistrationModels.Dto;

namespace project.Repositories.Abstruct
{
    public interface UserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(Registration RegistrationModel);
        Task LogoutAsync();

    }
}
