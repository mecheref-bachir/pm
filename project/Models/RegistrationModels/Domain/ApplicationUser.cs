using Microsoft.AspNetCore.Identity;

namespace project.Models.RegistrationModels.Domain
{
    public class ApplicationUser : IdentityUser
    {


        public string Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
