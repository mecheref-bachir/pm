using System.ComponentModel.DataAnnotations;

namespace project.Models.RegistrationModels.Dto
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
