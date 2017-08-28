using System.ComponentModel.DataAnnotations;

namespace CabrosoIdentityServer.Models
{
    public class PasswordRecovery
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}