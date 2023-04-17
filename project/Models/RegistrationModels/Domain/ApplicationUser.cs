using Microsoft.AspNetCore.Identity;

namespace project.Models.RegistrationModels.Domain
{
    public class ApplicationUser : IdentityUser
    {


        public string Name { get; set; }
        public bool isApproved { get; set; } = false;
        public string? ProfilePicture { get; set; }
    }
}
