using project.Models.PaymentModels;
using System.ComponentModel.DataAnnotations;

namespace project.Models.RegistrationModels.Dto
{
    public class Registration
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Role { get; set; }

        public string? PaymentMethod { get; set; }
        public long? CardNumber { get; set; }

        public int? CVV { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string?  Agreement { get; set; }
    }
}
